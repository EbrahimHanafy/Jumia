using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public Task<List<Department>> SearchForDepartments(string? departmentName, int? departmentId);

        public Task<bool> IsDepartmentHasTransactions(int departmentId);
        
    }
}
