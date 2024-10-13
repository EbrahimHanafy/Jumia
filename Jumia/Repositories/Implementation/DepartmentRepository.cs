using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        protected DbSet<Department> _departments;
        public DepartmentRepository(AppDBContext context) : base(context)
        {
            _departments = context.Set<Department>();
        }
    }
}
