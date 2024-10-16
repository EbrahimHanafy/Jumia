using Jumia.Models;
using Jumia.SharedRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Jumia.Repositories.Interfaces
{
    public interface IProductColorSizeRepository : IGenericRepository<ProductColorSize>
    {
        public Task<List<ProductColorSize>> GetProductColorSize(int productId);
        
    }
}
