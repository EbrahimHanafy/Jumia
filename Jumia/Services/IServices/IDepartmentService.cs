using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IDepartmentService 
    {
        public  Task<List<Category>> GetCategoriesByDepartment(int departmentId, string departmentName);
    }
}
