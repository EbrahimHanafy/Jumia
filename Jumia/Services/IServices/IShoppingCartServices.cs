using Jumia.Models;
using Jumia.ViewModels;

namespace Jumia.Services.IServices
{
    public interface IShoppingCartServices
    {
        public Task<ShoppingCart> AddToCart(ShoppingCart shoppingCart);
        public Task<List<ShoppingCartProductViewModel>?> GetShoppingCartProducts(int userCode);
        public Task RemoveProductFromCart(int shoppingCartId);
        //public Task<ShoppingCart> GetShoppingCartById(int shoppingCartId);
        public Task<bool> IsShoppingCartExisted(int productId, int productColorSizeId, int userCode);
    }
}
