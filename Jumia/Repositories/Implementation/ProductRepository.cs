using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        protected readonly DbSet<Product> _products;
        private readonly DbSet<ProductInStore> _productInStore;

        public ProductRepository(AppDBContext context) : base(context)
        {
            _products = context.Set<Product>();
            _productInStore = context.Set<ProductInStore>();
        }
        
        public async Task<List<Product>> GetProductsBySubCategory(int SubCategoryId)
        {
            return await _products.Where(s => s.SubCategoryId == SubCategoryId)
                                  .Include(c => c.ProductImages.Where(x => x.IsMainImage == true))
                                  .ToListAsync();
        }

        public async Task<List<Product>> GetTop10NewArrivalProducts()
        {
            return await _products.OrderByDescending(p=>p.CreatedAt).Take(10)
                .Include(p => p.ProductImages.Where(i => i.IsMainImage == true)).ToListAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await _products.Where(s => s.ProductId == productId)
                        .Include(i => i.ProductImages)
                        .Include(m => m.ProductMaterialsCares)
                        .Include(f => f.ProductFeatures)
                        .Include(pcs => pcs.ProductColorSizes)
                        .Include(pins => pins.ProductInStores)
                        .FirstOrDefaultAsync();
        }

        public async Task<int> GetAvailableQunitityOfProductById(int productId)
        {
            return await _productInStore
                        .Where(s => s.ProductId == productId)
                        .SumAsync(s => s.Quantity);
        }
    }
}
