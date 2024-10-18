using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IColorService
    {
        public Task<List<Color>> GetColorByProductAndSize(int productId);

        public Task<List<Color>> GetColorsBySize(int productId, int sizeId);
    }
}
