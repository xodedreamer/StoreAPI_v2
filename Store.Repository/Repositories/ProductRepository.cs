using Store.Domain.Interfaces.Repositories;
using Store.Domain.Models;
using Store.Repository.Contexts;
using Store.Repository.Repositories.Common;

namespace Store.Repository.Repositories
{
    public class ProductRepository : CrudRepository<Product>, IProductRepository
    {
        public ProductRepository(MainDbContext context) : base(context)
        {
        }
    }
}
