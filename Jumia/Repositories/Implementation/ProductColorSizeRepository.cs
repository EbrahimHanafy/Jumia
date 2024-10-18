using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<ProductColorSize>> GetProductColorSize(int productId)
        {
            return await _productColorSize.Where(s=>s.ProductId == productId)
                .Include(s=>s.Color)
                .Include(s=>s.Size)
                .ToListAsync();
        }
    }
}
