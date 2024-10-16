using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        public Task<List<Color>> GetColorByProductAndSize(int productId);

        public Task<List<Color>> GetColorsBySize(int productId, int sizeId);
    }
}
