using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        protected readonly DbSet<Product> _products;

        public ProductRepository(AppDBContext context) : base(context)
        {
            _products = context.Set<Product>();
        }
    }
}
