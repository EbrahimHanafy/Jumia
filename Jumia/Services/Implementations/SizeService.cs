using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;

namespace Jumia.Services.Implementations
{
    public class SizeService(IMapper mapper,ISizeRepository sizeRepository) : ISizeService
    {
        public async Task<List<Size>> GetSizesByProduct(int productId)
        {
            var sizes = await sizeRepository.GetSizesByProduct(productId);
            return mapper.Map<List<Size>>(sizes);
        }
    }
}