using Store.Domain.Interfaces.Repositories;
using Store.Domain.Models;
using Store.Repository.Contexts;
using Store.Repository.Repositories.Common;

namespace Store.Repository.Repositories
{
    public class OrderRepository : CrudRepository<Order>, IOrderRepository
    {
        public OrderRepository(MainDbContext context) : base(context)
        {
        }
    }
}
