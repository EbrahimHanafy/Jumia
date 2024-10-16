using Jumia.Models;
using Jumia.SharedRepositories;
using Jumia.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Jumia.Repositories.Implementation
{
	public class ProductRateRepository: GenericRepository<ProductRate>, IProductRateRepository
	{
		protected readonly DbSet<ProductRate> _productRates;
		//private readonly DbSet<User> _users;
		
		public ProductRateRepository(AppDBContext context) : base(context) 
		{
			_productRates = context.Set<ProductRate>();
			//_users = context.Set<User>();
		}

        public async Task<int> GetProductRatingAverage(int productId)
        {
            var filteredRates = await _productRates.Where(s => s.ProductId == productId).Select(s => s.Rate).ToListAsync();

            if (!filteredRates.Any())
            {
                return 0; // Or handle the case of no ratings appropriately
            }

            double averageRate = filteredRates.Average();
            return (int)Math.Round(averageRate);
        }
    }
}
