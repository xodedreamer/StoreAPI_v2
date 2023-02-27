using Microsoft.EntityFrameworkCore;

namespace Store.Repository.Config
{
    public interface IDbEntityConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
