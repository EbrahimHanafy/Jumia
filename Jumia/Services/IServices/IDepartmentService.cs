using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IDepartmentService 
    {
        public Task<List<Category>> GetCategoriesByDepartment(int departmentId, string departmentName);

        public Task<List<Department>> SearchForDepartments(string? departmentName, int? departmentId); 

        public Task<Department> AddNewDepartment(Department department);

        public Task<bool> IsDepartmentHasTransactions(int departmentId);

        public Task<bool> DeleteDepartment(int departmentId);

        public Task<Department> UpdateDepartment(Department department);
    }
}
