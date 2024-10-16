using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IProductColorSizeService
    {
        public Task<List<ProductColorSize>> GetProductColorSize(int productId);
    }
}
