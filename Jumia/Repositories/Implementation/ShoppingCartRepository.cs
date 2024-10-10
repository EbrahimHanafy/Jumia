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
	}
}
