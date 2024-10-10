using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ProductColorSizeRepository : GenericRepository<ProductColorSize>, IProductColorSizeRepository
    {
        protected readonly DbSet<ProductColorSize> _productColorSize;
        
        public ProductColorSizeRepository(AppDBContext context) : base(context)
        {
            _productColorSize = context.Set<ProductColorSize>();
        }
    }
}
