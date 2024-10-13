using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Jumia.Models

{
    public class AppDBContext : IdentityDbContext<User>
    {
        //create default constructor
        public AppDBContext() { }

        //create override base constructor
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:sqldepi.database.windows.net,1433;Initial Catalog=ECommerceDB;Persist Security Info=False;User ID=dbadmin;Password=Db#201093;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
        //}

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public virtual DbSet<Governorate> Governorates { get; set; }
        public virtual DbSet<MaterialsCare> MaterialsCares { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductColorSize> ProductColorSizes { get; set; }
        public virtual DbSet<ProductFeature> ProductFeatures { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductInStore> ProductInStores { get; set; }
        public virtual DbSet<ProductMaterialsCare> ProductMaterialsCares { get; set; }
        public virtual DbSet<ProductRate> ProductRates { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<ReturnDetails> ReturnDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        //Why? Beacause Ternary Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.City)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(ua => ua.CityId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for City

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Country)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(ua => ua.CountryId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for Country

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Governorate)
                .WithMany(g => g.UserAddresses)
                .HasForeignKey(ua => ua.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for Governorate

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for User

            modelBuilder.Entity<ProductColorSize>()
                .HasOne(ua => ua.Product)
                .WithMany(u => u.ProductColorSizes)
                .HasForeignKey(ua => ua.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for Product
            
            modelBuilder.Entity<ProductInStore>()
                .HasOne(ua => ua.Product)
                .WithMany(u => u.ProductInStores)
                .HasForeignKey(ua => ua.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for Product
            
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(ua => ua.Product)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(ua => ua.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for Product

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId});
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.RoleId});
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId });
            });
            // modelBuilder.Entity<IdentityUserLogin<>>().HasKey(u => u.UserId);

        }
    }
}
