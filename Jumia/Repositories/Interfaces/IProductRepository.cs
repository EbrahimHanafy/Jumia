using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<Product>> GetProductsBySubCategory(int SubCategoryId);

        public Task<List<Product>> GetProductsByBrand(int BrandId);

        public Task<List<Product>> GetTop10NewArrivalProducts();

        public Task<Product> GetProductById(int productId);

        public Task<int> GetAvailableQunitityOfProductById(int productId);
    }
}
