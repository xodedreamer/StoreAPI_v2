using MediatR;
using Store.Domain.Events.Product;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Domain.Handlers.Events
{
    public class ProductEventHandler : INotificationHandler<CreateProductEvent>, INotificationHandler<UpdateProductEvent>, INotificationHandler<DeleteProductEvent>
    {
        public Task Handle(CreateProductEvent notification, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task Handle(UpdateProductEvent notification, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task Handle(DeleteProductEvent notification, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
