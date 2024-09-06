using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class ProductInStore
    {
        [Key]
        public Int64 ProductInStoreId { get; set; }
               
        [Required, NotNull]
        public int Quantity { get; set; }

        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        
        // Foreign key to Product
        [Required]
        public int ProductId { get; set; }
        // Foreign key to Store
        [Required]
        public int StoreId { get; set; }
        // Foreign key to ProductColorSize
        [Required]
        public int ProductColorSizeId { get; set; }

        // Navigation property for the related Product
        public virtual Product Product { get; set; }
        // Navigation property for the related Store
        public virtual Store Store { get; set; }
        // Navigation property for the related ProductColorSize
        public virtual ProductColorSize ProductColorSize { get; set; }
    }
}
