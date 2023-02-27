using Store.Domain.Interfaces.Repositories;
using Store.Domain.Models;
using Store.Repository.Contexts;
using Store.Repository.Repositories.Common;

namespace Store.Repository.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }
    }
}
