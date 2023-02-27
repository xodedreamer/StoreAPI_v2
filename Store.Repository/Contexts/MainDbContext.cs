using Microsoft.EntityFrameworkCore;
using Store.Repository.Config;
using Store.Repository.Mapping.Common;
using System.Reflection;

namespace Store.Repository.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddAssemblyConfiguration<IEntityMap>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
