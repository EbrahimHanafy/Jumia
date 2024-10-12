using AutoMapper;
using Jumia.UnitOfWorks;
using Jumia.Repositories.Interfaces;
using Jumia.Models;
using Jumia.Services.IServices;
using Microsoft.EntityFrameworkCore;
namespace Jumia.Services.Implementations
{
    public class DepartmentService(IUnitOfWork unitOfWork, IMapper mapper,  AppDBContext context) : IDepartmentService
    {  
        public async Task<List<Category>> GetCategoriesByDepartment(int departmentId, string departmentName)
        {
                var categories = context.Categories
                                        .Where(s => s.DepartmentId == departmentId)
                                        .Include(c => c.SubCategories)
                                        .ToList();
                return mapper.Map<List<Category>>(categories);
        }
    }
}