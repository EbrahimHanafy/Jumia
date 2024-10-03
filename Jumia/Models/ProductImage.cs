using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        
        [StringLength(45), Required, NotNull]
        public string ProductImageName { get; set; }
        
        public bool IsMainImage { get; set; }
        
        [StringLength(250), Required, NotNull]
        public string ProductImageUrl { get; set; }

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
        
        // Navigation property for the related Product
        public virtual Product Product { get; set; }
    }
}
