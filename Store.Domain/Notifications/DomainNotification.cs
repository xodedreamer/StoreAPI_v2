using Store.Domain.Events.Common;

namespace Store.Domain.Notifications
{
    public class DomainNotification : Event
    {
        public string Message { get; private set; }

        public DomainNotification(string message)
        {
            Message = message;
        }
    }
}
