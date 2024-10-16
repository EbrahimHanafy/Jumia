using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class ShoppingCartRepository : GenericRepository<ShoppingCart> , IShoppingCartRepository
	{
		protected readonly DbSet<ShoppingCart> _shoppingCarts;
        

		public ShoppingCartRepository(AppDBContext context) : base(context) 
		{
			_shoppingCarts = context.Set<ShoppingCart>();
		}

        public Task AddProductToCart(int productId, int quantity, int ProductColorSizeId)
        {
            throw new NotImplementedException();
        }

        public Task DecreaseItemQty(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetCartProducts(int userCode)
        {
            throw new NotImplementedException();
        }

        public Task IncreaseItemQty(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
