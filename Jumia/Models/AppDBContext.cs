using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace Jumia.Models

{
    public class AppDBContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ECommerceDB;Integrated Security=True;Encrypt=False");
        }

     // public virtual DbSet<Brand> Brands { get; set; }
      //  public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
       // public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
      //  public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Disclaimer> Disclaimers { get; set; }
        public virtual DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public virtual DbSet<Governorate> Governorates { get; set; }
      //  public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MaterialsCare> MaterialsCares { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
       // public virtual DbSet<ProductColorSize> ProductColorSizes { get; set; }
        public virtual DbSet<ProductFeature> ProductFeatures { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductInStore> ProductInStores { get; set; }
        public virtual DbSet<ProductMaterialsCare> ProductMaterialsCares { get; set; }
        public virtual DbSet<ProductRate> ProductRates { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<ReturnDetails> ReturnDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
       // public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
       // public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

    }
}
