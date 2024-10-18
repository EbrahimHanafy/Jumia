using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IProductRateService
    {
        public Task<ProductRate> AddProductRateService(ProductRate productRate);
        
        public Task<int> GetProductRatingAverage(int prodcutId);

        public Task<int> GetNumberOfProductRates(int prodcutId);

       
    }
}
