using Microsoft.EntityFrameworkCore;
using Store.Repository.Config;
using Store.Repository.Mapping.Common;

namespace Store.Repository.Contexts
{
    public class EventStoreSQLContext : DbContext
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddAssemblyConfiguration<IEventMap>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
