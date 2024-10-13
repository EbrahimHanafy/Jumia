using Jumia.Models;
using Jumia.Repositories.Implementation;
using Jumia.Repositories.Interfaces;
using Jumia.Services.Implementations;
using Jumia.Services.IServices;
using Jumia.SharedRepositories;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Jumia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDBContext>(); // This adds default token providers (used for things like password reset)

            //DI register one instance for the same request
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IBrandRepository, BrandRepository>();
            //builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

            builder.Services.AddTransient<IDepartmentService, DepartmentService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


            //AutoMapper
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Ensure this is added
            app.UseAuthorization();  // Ensure this is added

            // Default route (Home page)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Admin route (Admin dashboard and related pages)
            app.MapControllerRoute(
                name: "admin",
                pattern: "admin/{action=Index}",
                defaults: new { controller = "Admin" }
            );

            // Category route (Category pages)
            app.MapControllerRoute(
                name: "categories",
                pattern: "categories/{action}",
                defaults: new { controller = "Categories" }
            );

            // Subcategory route (e.g., /subcategory/pants)
            app.MapControllerRoute(
                name: "subcategory",
                pattern: "subcategory/{subcategory}",
                defaults: new { controller = "Subcategory", action = "Index" }
            );
         


            app.Run();
        }
    }
}
