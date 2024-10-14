using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface IMaterialsCareRepository : IGenericRepository<MaterialsCare>
    {
        public Task<List<MaterialsCare>> GetMaterialByProduct(int productId);
    }
}
