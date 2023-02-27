using MediatR;
using Store.Domain.Events.Product;
using Store.Domain.Bus;
using Store.Domain.Commands.Product;
using Store.Domain.Handlers.Common;
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Interfaces.Repositories.Common;
using Store.Domain.Models;
using Store.Domain.Notifications;
using Store.Utils.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Domain.Handlers.Commands
{
    public class ProductCommandHandler : CommandHandler, IRequestHandler<CreateProductCommand, Product>, IRequestHandler<UpdateProductCommand>, IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository productRepository;

        public ProductCommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IProductRepository productRepository
        ) : base(uow, bus, notifications)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            request
                .IsNullEmptyOrWhitespace(e => e.Name, async () => await bus.InvokeDomainNotificationAsync("Invalid name."))
                .Is(e => e.Price <= 0, async () => await bus.InvokeDomainNotificationAsync("Invalid price."));

            var entity = new Product(request.Name, request.Description, request.Price);

            if (request.PicturesUrls != null)
                foreach (var pictureUrl in request.PicturesUrls)
                    entity.AddPicture(pictureUrl);

            await productRepository.AddAsync(entity);

            Commit();
            await bus.InvokeAsync(new CreateProductEvent(entity.Id, entity.Name, entity.Description, entity.Price, entity.GetPictureUrls()));

            return entity;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var original = await productRepository.GetAsync(request.Id); // -> Get entity from db.

            if (original == null) // -> If it is null, notificate and stop to avoid null exception.
            {
                await bus.InvokeDomainNotificationAsync("Not found.");
                return Unit.Value;
            }

            request
                .IsNullEmptyOrWhitespace(e => e.Name, async () => await bus.InvokeDomainNotificationAsync("Invalid name."))
                .Is(e => e.Price <= 0, async () => await bus.InvokeDomainNotificationAsync("Invalid price."));

            original.UpdateInfo(request.Name, request.Description, request.Price);

            await productRepository.UpdateAsync(original);

            Commit();
            await bus.InvokeAsync(new UpdateProductEvent(original.Id, original.Name, original.Description, original.Price));

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.DeleteAsync(request.Id);

            Commit();
            await bus.InvokeAsync(new DeleteProductEvent(request.Id));

            return Unit.Value;
        }

        public void Dispose() => productRepository.Dispose();
    }
}
