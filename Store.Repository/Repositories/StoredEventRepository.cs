using Newtonsoft.Json;
using Store.Domain.Events.Common;
using Store.Domain.Interfaces.Identity;
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Models;
using Store.Repository.Contexts;
using Store.Repository.Repositories.Common;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class StoredEventRepository : CrudRepository<StoredEvent>, IStoredEventRepository
    {
        private readonly IUser user;

        public StoredEventRepository(EventStoreSQLContext context, IUser user) : base(context) => this.user = user;

        public async Task AddEventAsync<TEvent>(TEvent @event) where TEvent : Event
        {
            await AddAsync(new StoredEvent(@event, JsonConvert.SerializeObject(@event), user?.Name));
            await context.SaveChangesAsync();
        }
    }
}
