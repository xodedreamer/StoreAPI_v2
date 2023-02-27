using Store.Domain.Interfaces.Repositories.Common;
using Store.Domain.Models;

namespace Store.Domain.Interfaces.Repositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
    }
}
