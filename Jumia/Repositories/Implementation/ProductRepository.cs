using Jumia.DTO;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Jumia.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        protected readonly DbSet<Product> _products;
        private readonly DbSet<ProductInStore> _productInStore;
        private readonly DbSet<WishList> _wishList;
        private readonly DbSet<ProductImage> _productImages;

        public ProductRepository(AppDBContext context) : base(context)
        {
            _products = context.Set<Product>();
            _productInStore = context.Set<ProductInStore>();
            _wishList = context.Set<WishList>();
            _productImages = context.Set<ProductImage>();
        }
        
        public async Task<List<Product>> GetProductsBySubCategory(int SubCategoryId)
        {
            return await _products.Where(s => s.SubCategoryId == SubCategoryId)
                                  .Include(c => c.ProductImages.Where(x => x.IsMainImage == true))
                                  .ToListAsync();
        }
        public async Task<List<Product>> GetProductsByBrand(int BrandId) 
        {
            return await _products.Where(s => s.BrandId == BrandId)
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

        public async Task<List<WishListProductViewModel>> GetWishListProducts(int userCode)
        {
            return await (from p in _products
                          join pi in _productImages on p.ProductId equals pi.ProductId
                          join w in _wishList on p.ProductId equals w.ProductId
                          where w.UserCode == userCode && pi.IsMainImage == true
                          orderby w.CreatedAt descending
                          select new WishListProductViewModel
                          {
                              Product = p,
                              Image = pi
                          }
                          ).ToListAsync();
        }
    }
}
