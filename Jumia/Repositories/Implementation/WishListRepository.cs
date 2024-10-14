using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class WishListRepository : GenericRepository<WishList> , IWishListRepository
	{
		protected readonly DbSet<WishList> _wishLists;

		public WishListRepository(AppDBContext context) : base(context) 
		{
			_wishLists = context.Set<WishList>();
		}
	}
}
