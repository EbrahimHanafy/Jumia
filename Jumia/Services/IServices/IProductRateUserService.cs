using Jumia.DTO;

namespace Jumia.Services.IServices
{
	public interface IProductRateUserService
	{
		public Task<List<ProductRateUser>> GetProductRatesByProductId(int productId);
	}
}
