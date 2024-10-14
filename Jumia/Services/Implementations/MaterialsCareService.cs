using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;

namespace Jumia.Services.Implementations
{
    public class MaterialsCareService(IMapper mapper,IMaterialsCareRepository materialsCareRepository) : IMaterialsCareService
    {
        public async Task<List<MaterialsCare>> GetMaterialByProduct(int productId)
        {
            var materialsCare = await materialsCareRepository.GetMaterialByProduct(productId);

            return mapper.Map<List<MaterialsCare>>(materialsCare);
        }
    }
}
