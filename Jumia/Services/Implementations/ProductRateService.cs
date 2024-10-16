using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;

namespace Jumia.Services.Implementations
{
    public class ProductRateService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductRateService> logger, IProductRateRepository productRateRepository) : IProductRateService
    {
        public async Task<ProductRate> AddProductRateService(ProductRate productRate)
        {
            var newProductRate = mapper.Map<ProductRate>(productRate);

            try
            {
                //logger.LogInformation($"Attempting to insert new product rate for product ID: {productRate.ProductId}");

                await unitOfWork.Repository<ProductRate>().InsertAsync(newProductRate);
                //logger.LogInformation("Product rate inserted successfully");

                //logger.LogInformation("Saving changes");
                await unitOfWork.Save();  // Save changes, let EF handle the transaction
                //logger.LogInformation("Changes saved successfully");
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "An error occurred while adding rate to this product");
                throw new Exception("An error occurred while adding rate to this product");
            }

            return mapper.Map<ProductRate>(newProductRate);
        }

        public Task<int> GetProductRatingAverage(int prodcutId)
        {
           return productRateRepository.GetProductRatingAverage(prodcutId);
        }
    }
}