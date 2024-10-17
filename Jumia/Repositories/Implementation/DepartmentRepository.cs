using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository 
    {
        protected DbSet<Department> _departments;
        private DbSet<Category> _categories;
        public DepartmentRepository(AppDBContext context) : base(context)
        {
            _departments = context.Set<Department>();
            _categories = context.Set<Category>();
        }
        public async Task<List<Department>> SearchForDepartments(string? departmentName, int? departmentId)
        {
            // Start with the base query
            var query = _departments.AsQueryable();

            // Apply the department name filter if part of a word is provided
            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                query = query.OrderBy(s=>s.DepartmentName)
                             .Where(s => s.DepartmentName.Contains(departmentName));
            }
            // Apply the department ID filter if provided
            if (departmentId.HasValue)
            {
                query = query.Where(s => s.DepartmentId == departmentId.Value);
            }

            // Execute the query and return the results
            return await query.ToListAsync();
        }

        public async Task<bool> IsDepartmentHasTransactions(int departmentId)
        {
            return await _categories.Where(s => s.DepartmentId == departmentId).AnyAsync();
        }
    }
}
