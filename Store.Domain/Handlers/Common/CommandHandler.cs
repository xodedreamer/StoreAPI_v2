using MediatR;
using Store.Domain.Bus;
using Store.Domain.Interfaces.Repositories.Common;
using Store.Domain.Notifications;

namespace Store.Domain.Handlers.Common
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork uow;
        private readonly DomainNotificationHandler notifications;
        protected readonly IMediatorHandler bus;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            this.uow = uow;
            this.bus = bus;
            this.notifications = (DomainNotificationHandler)notifications;
        }

        protected bool IsValidOperation() => !notifications.HasNotifications();

        public void Commit()
        {
            if (IsValidOperation())
                uow.Commit();
        }
    }
}
