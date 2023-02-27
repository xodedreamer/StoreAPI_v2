using Store.Domain.Events.Common;

namespace Store.Domain.Events.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
