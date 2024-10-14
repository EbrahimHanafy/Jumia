using Jumia.Models;
using Jumia.SharedRepositories;
using Jumia.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Jumia.Repositories.Implementation
{
	public class ProductFeatureRepository : GenericRepository<ProductFeature>, IProductFeatureRepository
	{
		protected readonly DbSet<ProductFeature> _productFeatures;

		public ProductFeatureRepository(AppDBContext context) : base(context)
		{
			_productFeatures = context.Set<ProductFeature>();
		}
        
    }
}
