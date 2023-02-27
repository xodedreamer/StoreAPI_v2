using Store.Domain.Events.Common;
using Store.Domain.Interfaces.Repositories.Common;
using Store.Domain.Models;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces.Repositories
{
    public interface IStoredEventRepository : ICrudRepository<StoredEvent>
    {
        Task AddEventAsync<TEvent>(TEvent @event) where TEvent : Event;
    }
}
