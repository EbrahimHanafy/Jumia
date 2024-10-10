using Jumia.Models;
using Jumia.SharedRepositories;
using Jumia.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class ProductInStoreRepository :GenericRepository<ProductInStore>, IProductInStoreRepository
	{
		protected readonly DbSet<ProductInStore> _productInStores;

		public ProductInStoreRepository(AppDBContext context): base(context)
		{
			_productInStores = context.Set<ProductInStore>();
		}
	}
}
