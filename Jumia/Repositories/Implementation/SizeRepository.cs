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
			return await (from s in _sizes
						  join ps in _productColorSize on s.SizeId equals ps.SizeId
						  where ps.ProductId == productId
						  select s).ToListAsync();
        }
    }
}