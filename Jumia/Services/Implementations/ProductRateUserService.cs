using AutoMapper;
using Jumia.DTO;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;

namespace Jumia.Services.Implementations
{
	public class ProductRateUserService(IProductRateUserRepository productRateUserRepository, IMapper mapper ) : IProductRateUserService
	{
		public async Task<List<ProductRateUser>> GetProductRatesByProductId(int productId)
		{
			var ProductRates = await productRateUserRepository.GetProductRatesByProductId(productId);
			return mapper.Map<List<ProductRateUser>>(ProductRates);
		}
	}
}
