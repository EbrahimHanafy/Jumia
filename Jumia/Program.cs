namespace Jumia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

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
