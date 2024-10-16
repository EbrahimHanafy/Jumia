using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;

namespace Jumia.Services.Implementations
{
    public class ProductColorSizeService(IMapper mapper,IProductColorSizeRepository productColorSizeRepository) : IProductColorSizeService
    {
        public async Task<List<ProductColorSize>> GetProductColorSize(int productId)
        {
            var ProductColorSizes = await productColorSizeRepository.GetProductColorSize(productId);
            
            return mapper.Map<List<ProductColorSize>>(ProductColorSizes);
        }
    }
}
