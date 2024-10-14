using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class ProductMaterialsCareRepository: GenericRepository<ProductMaterialsCare>, IProductMaterialsCareRepository
	{
		protected readonly DbSet<ProductMaterialsCare> _productMaterialsCares;
		
		public ProductMaterialsCareRepository(AppDBContext context) : base(context) 
		{
			_productMaterialsCares = context.Set<ProductMaterialsCare>();
		}
	}
}
