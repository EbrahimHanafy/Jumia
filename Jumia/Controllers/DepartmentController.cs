using Jumia.Models;
using Jumia.Services.Implementations;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Jumia.Controllers
{
    public class DepartmentController(IUnitOfWork unitOfWork, IDepartmentService departmentService) : Controller
    {
        public async Task<IActionResult> GetCategoriesByDepartment(int departmentId, string departmentName)
        {
            var departmentCategories = await departmentService.GetCategoriesByDepartment(departmentId, departmentName);
            ViewData["DepartmentName"] = departmentName;
            return View("Index", departmentCategories);
        }

        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await unitOfWork.Repository<Department>().GetAllAsync();
            return View("~/Views/Admin/Departments.cshtml", departments);
        }

        public async Task<IActionResult> GetDepartmentById(int departmentId)
        {
            Department department = await unitOfWork.Repository<Department>().GetByIdAsync(departmentId);
            return View("~/Views/Admin/DepartmentDetails.cshtml", department);
        }

        public async Task<IActionResult> SearchForDepartments(string searchTerm)
        {
            List<Department> departments;

            // Try to parse the input as an integer (for departmentId)
            if (int.TryParse(searchTerm, out int departmentId))
            {
                // Search by departmentId if input is an integer
                departments = await departmentService.SearchForDepartments(null, departmentId);
            }
            else
            {
                // Otherwise, search by departmentName (assuming input is a string)
                departments = await departmentService.SearchForDepartments(searchTerm, null);
            }

            return View("~/Views/Admin/Departments.cshtml", departments);
        }

        public async Task<IActionResult> AddNewDepartment(Department department, IFormFile? departmentImage)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/AddNewDepartment.cshtml", department);
            }

            try
            {
                if (departmentImage != null && departmentImage.Length > 0)
                {
                    // Get the file extension
                    var fileExtension = Path.GetExtension(departmentImage.FileName);

                    // Create a unique filename by appending the current DateTime
                    var uniqueFileName = $"{Path.GetFileNameWithoutExtension(departmentImage.FileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{fileExtension}";

                    // Define the path to save the image
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Department", uniqueFileName);

                    // Ensure the directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                    // Save the image file to the specified path
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await departmentImage.CopyToAsync(fileStream);
                    }

                    // Set the ImageURL property to the relative path for database storage
                    department.ImageURL = $"/Images/Department/{uniqueFileName}";
                }

                // Set additional properties
                department.CreatedBy = 7; // Replace with the actual user if available
                department.CreatedAt = DateTime.UtcNow;

                // Save the department to the database
                await departmentService.AddNewDepartment(department);

                // Redirect to the department details page after successfully adding the department
                return RedirectToAction("GetDepartmentById", new { departmentId = department.DepartmentId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("~/Views/Admin/AddNewDepartment.cshtml", department);
            }
        }

        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            if (await departmentService.IsDepartmentHasTransactions(departmentId))
            {
                TempData["Message"] = "This department has no transactions.  No action taken.";
                    return RedirectToAction("GetAllDepartments");
            }
            else
            { 
                if (await departmentService.DeleteDepartment(departmentId))
                {
                    TempData["Message"] = "Department deleted successfully.";
                    return RedirectToAction("GetAllDepartments");
                }
                else
                {
                    TempData["Message"] = "An error occurred while deleting the department. Please try again later.";
                    return RedirectToAction("GetAllDepartments");
                }
            }
        }
    }
}