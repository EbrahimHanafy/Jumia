using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        public Task<List<Color>> GetColorByProductAndSize(int productId);
    }
}
