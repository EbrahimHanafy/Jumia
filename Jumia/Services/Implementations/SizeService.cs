using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Implementation;
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
        public async Task<List<Size>> GetSizesByColor(int productId, int colorId)
        {
            var Sizes = await sizeRepository.GetSizesByColor(productId, colorId);
            return mapper.Map<List<Size>>(Sizes);
        }
    }
}