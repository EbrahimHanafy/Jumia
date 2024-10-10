using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;
namespace Jumia.Repositories.Implementation
{
	public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
	{
		protected readonly DbSet<ProductImage> _productImages;

		public ProductImageRepository(AppDBContext context) : base(context)

		{
			_productImages = context.Set<ProductImage>();

		}
	}
}
