using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Jumia.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        protected readonly DbSet<ShoppingCart> _shoppingCarts;
        private readonly DbSet<Product> _products;
        private readonly DbSet<ProductImage> _productImages;
        private readonly DbSet<ProductColorSize> _productColorSizes;
        private readonly DbSet<Color> _colors;
        private readonly DbSet<Size> _sizes;


        public ShoppingCartRepository(AppDBContext context) : base(context)
        {
            _shoppingCarts = context.Set<ShoppingCart>();
            _products = context.Set<Product>();
            _productImages = context.Set<ProductImage>();
            _productColorSizes = context.Set<ProductColorSize>();
            _colors = context.Set<Color>();
            _sizes = context.Set<Size>();
        }

        public async Task<List<ShoppingCartProductViewModel>> GetShoppingCartProducts(int userCode)
        {
            return await (from sh in _shoppingCarts
                          join p in _products on sh.ProductId equals p.ProductId into productGroup
                          from p in productGroup.DefaultIfEmpty()  // Left join with Products

                          join pi in _productImages on sh.ProductId equals pi.ProductId into imageGroup
                          from pi in imageGroup.DefaultIfEmpty()  // Left join with ProductImages

                          join cs in _productColorSizes on sh.ProductColorSizeId equals cs.ProductColorSizeId into colorSizeGroup
                          from cs in colorSizeGroup.DefaultIfEmpty()  // Left join with ProductColorSizes

                          where sh.UserCode == userCode && (pi == null || pi.IsMainImage)  // Main image check or null

                          select new ShoppingCartProductViewModel
                          {
                              shoppingCart = sh,
                              product = p,
                              image = pi,
                              color = cs.Color,
                              size = cs.Size
                          }).ToListAsync();
        }

        public async Task<bool> IsShoppingCartExisted(int productId, int productColorSizeId, int userCode)
        {
            return await _shoppingCarts.Where(s => s.ProductId == productId && s.ProductColorSizeId == productColorSizeId && s.UserCode == userCode).AnyAsync();
        }
    }
}