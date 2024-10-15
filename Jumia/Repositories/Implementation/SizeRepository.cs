using Jumia.Repositories.Interfaces;
using Jumia.Models;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class SizeRepository : GenericRepository<Size> , ISizeRepository
	{
		protected readonly DbSet<Size> _sizes;
		private readonly DbSet<ProductColorSize> _productColorSize;

		public SizeRepository(AppDBContext context) : base(context) 
		{
			_sizes = context.Set<Size>();
            _productColorSize = context.Set<ProductColorSize>();
        }

        public async Task<List<Size>> GetSizesByProduct(int productId)
		{
			var Sizes = await (from size in _sizes
						  join productColorSize in _productColorSize
						  on size.SizeId equals productColorSize.SizeId
						  where productColorSize.ProductId == productId
						  select size)
                          .Distinct()
                          .ToListAsync();
			return Sizes;
        }
    }
}