using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
	public interface IProductRateRepository: IGenericRepository<ProductRate>
	{
        public Task<int> GetProductRatingAverage(int prodcutId);
    }
}
