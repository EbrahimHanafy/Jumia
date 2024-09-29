using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(20, MinimumLength = 12, ErrorMessage = "Barcode should be between 12 and 20 charcters"), AllowNull]
        public string? BarCode { get; set; }

        [StringLength(100), Required]
        public string ProductName { get; set; }

        [DataType(DataType.Currency), Required, NotNull]
        public double Price { get; set; }

        [DataType(DataType.Currency), AllowNull]
        public double? Discount { get; set; }

        [Range(0, 9.99, ErrorMessage = "Please enter a value between 0 and 9.99"), AllowNull]
        public double? DiscountPersentage { get; set; }

        [StringLength(250), AllowNull]
        public string? Description { get; set; }

        [Required, NotNull]
        public bool IsLowInStore { get; set; }

        [Required, NotNull]
        public bool IsDeleted { get; set; }

        [Required, NotNull]
        public bool IsActive { get; set; }

        [Required, NotNull]
        public int MinimumQuantity { get; set; }

        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        
        // Foreign key to Brand
        [Required]
        public int BrandId { get; set; }
        // Foreign key to SubCategory
        [Required]
        public int SubCategoryId { get; set; }

        // Navigation property for related ProductMaterialsCare entities (one-to-many relationship)
        public virtual ICollection<ProductMaterialsCare> ProductMaterialsCares { get; set; }
        // Navigation property for related ProductFeature entities (one-to-many relationship)
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        // Navigation property for related ProductRate entities (one-to-many relationship)
        public virtual ICollection<ProductRate>? ProductRates { get; set; }
        // Navigation property for related ProductImage entities (one-to-many relationship)
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        // Navigation property for the related SubCategory
        public virtual SubCategory SubCategory { get; set; }
        // Navigation property for the related Brand
        public virtual Brand? Brand { get; set; }
        // Navigation property for related ProductColorSize entities (one-to-many relationship)
        public virtual ICollection<ProductColorSize> ProductColorSizes { get; set; }
        // Navigation property for related ProductInStore entities (one-to-many relationship)
        public virtual ICollection<ProductInStore> ProductInStores { get; set; }
        // Navigation property for related ShoppingCart entities (one-to-many relationship)
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        // Navigation property for related OrderDetails entities (one-to-many relationship)
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        // Navigation property for related ReturnDetails entities (one-to-many relationship)
        public virtual ICollection<ReturnDetails> ReturnDetails { get; set; }
        // Navigation property for related WishList entities (one-to-many relationship)
        public virtual ICollection<WishList>? WishLists { get; set; }

    }
}
