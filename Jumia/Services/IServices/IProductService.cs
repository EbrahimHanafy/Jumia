using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Services.IServices
{
    public interface IProductService 
    {
        public Task<List<Product>> GetProductsBySubCategory(int SubCategoryId);

        public Task<List<Product>> GetTop10NewArrivalProducts();

        public Task<List<Product>> GetProductById(int productId);

    }
}
