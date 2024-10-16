using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IShoppingCartServices
    {
        public Task<ShoppingCart> AddToCart(ShoppingCart shoppingCart);
    }
}
