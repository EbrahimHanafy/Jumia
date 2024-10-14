using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IMaterialsCareService
    {
        public Task<List<MaterialsCare>> GetMaterialByProduct(int productId);
    }
}
