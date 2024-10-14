using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<Product>> GetProductsBySubCategory(int SubCategoryId);

        public Task<List<Product>> GetTop10NewArrivalProducts();

        public Task<List<Product>> GetProductById(int productId);
    }
}
