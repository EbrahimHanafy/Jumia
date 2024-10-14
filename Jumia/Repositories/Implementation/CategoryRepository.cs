using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        protected readonly DbSet<Category> _categories;
        public CategoryRepository(AppDBContext context) : base(context)
        {
            _categories = context.Set<Category>();
        }

        public async Task<List<Category>> GetCategoriesByDepartment(int departmentId, string departmentName)
        {
            return _categories.Where(s => s.DepartmentId == departmentId).Include(c => c.SubCategories).ToList();
        }
    }
}
