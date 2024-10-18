using AutoMapper;
using Jumia.UnitOfWorks;
using Jumia.Repositories.Interfaces;
using Jumia.Models;
using Jumia.Services.IServices;
using Microsoft.EntityFrameworkCore;
namespace Jumia.Services.Implementations
{
    public class DepartmentService(IUnitOfWork unitOfWork, IMapper mapper, AppDBContext context, IDepartmentRepository departmentRepository) : IDepartmentService
    {  
        public async Task<List<Category>> GetCategoriesByDepartment(int departmentId, string departmentName)
        {
                var categories = context.Categories
                                        .Where(s => s.DepartmentId == departmentId)
                                        .Include(c => c.SubCategories)
                                        .ToList();
                return mapper.Map<List<Category>>(categories);
        }
        
        public async Task<List<Department>> SearchForDepartments(string? departmentName, int? departmentId)
        {
            var departments = await departmentRepository.SearchForDepartments(departmentName, departmentId);
            return mapper.Map<List<Department>>(departments);
        }
        
        public async Task<Department> AddNewDepartment(Department department)
        {
            var newDepartment = mapper.Map<Department>(department);
            try
            {
                await unitOfWork.Repository<Department>().InsertAsync(department);
                await unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding new department.");
            }
            return mapper.Map<Department>(department);
        }

        public async Task<bool> IsDepartmentHasTransactions(int departmentId)
        {
            return await departmentRepository.IsDepartmentHasTransactions(departmentId);
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            try
            {
                // Check if the department exists
                var department = await unitOfWork.Repository<Department>().GetByIdAsync(departmentId);
                if (department == null)
                {
                    // Optionally, return false or throw an exception if the department is not found
                    return false;
                }

                // Perform the deletion
                await unitOfWork.Repository<Department>().DeleteAsync(departmentId);

                // Optionally delete the old image file if it exists
                if (!string.IsNullOrEmpty(department.ImageURL))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", department.ImageURL.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                // Save the changes
                await unitOfWork.Save();

                return true; // Deletion successful
            }
            catch (Exception ex)
            {
                // Log the exception and handle it accordingly
                // Example: logger.LogError(ex, "Error deleting department");

                return false; // Return false in case of failure
            }
        }
        
        public async Task<Department> UpdateDepartment(Department department)
        {
            // Fetch the existing department from the database to ensure it exists
            var existingDepartment = await context.Departments.FindAsync(department.DepartmentId);

            if (existingDepartment == null)
            {
                throw new ArgumentException("Department not found");
            }
            // Map the new department data to the existing one
            mapper.Map(department, existingDepartment);

            // Save changes to the database
            try
            {
                context.Departments.Update(existingDepartment);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency issues, for example, by throwing a custom error
                throw new Exception("Failed to update the department due to a concurrency issue.", ex);
            }
            catch (Exception ex)
            {
                // Handle other types of errors
                throw new Exception("An error occurred while updating the department.", ex);
            }

            // Return the updated department
            return existingDepartment;
        }
    }
}