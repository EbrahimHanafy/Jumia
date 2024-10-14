using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<List<Category>> GetCategoriesByDepartment(int departmentId, string departmentName);
    
    }
}
