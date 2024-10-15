using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IProductRateService
    {
        public Task<ProductRate> AddProductRateService(ProductRate productRate);
    }
}
