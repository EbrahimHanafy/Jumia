using Jumia.DTO;

namespace Jumia.Repositories.Interfaces
{
	public interface IProductRateUserRepository
	{
		public Task<List<ProductRateUser>> GetProductRatesByProductId(int productId);
	}
}
