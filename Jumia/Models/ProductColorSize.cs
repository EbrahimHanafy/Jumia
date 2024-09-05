using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class ProductColorSize
    {
        [Key]
        public int ProductColorSizeId { get; set; }

        // Common fields
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Foreign Key to Product
        [Required]
        public int ProductId { get; set; }

        // Foreign Key to Color
        [Required]
        public int ColorId { get; set; }

        // Foreign Key to Size
        [Required]
        public int SizeId { get; set; }

        // Foreign Key to ProductImage
        [Required]
        public int ProductImageId { get; set; }

        // Navigation properties
        // Navigation property for the related Product
        public virtual Product Product { get; set; }

        // Navigation property for the related Color
        public virtual Color? Color { get; set; }
        // Navigation property for the related Size
        public virtual Size Size { get; set; }
        // Navigation property for the related ProductImage
        public virtual ProductImage ProductImage { get; set; }

        // Navigation property for related ProductInStores entities (one-to-many relationship)
        public virtual ICollection<ProductInStore> ProductInStores { get; set; }

        // Navigation property for related ShippingCart entities (one-to-many relationship)
        public virtual ICollection<ShoppingCart> ShippingCarts { get; set; }
    }
}
