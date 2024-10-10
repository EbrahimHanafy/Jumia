using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class StoreRepository : GenericRepository<Store>, IStoreRepository
	{
		protected readonly DbSet<Store> _stores;

		public StoreRepository(AppDBContext context) : base(context) 
		{
			_stores = context.Set<Store>();
		}
	}
}
