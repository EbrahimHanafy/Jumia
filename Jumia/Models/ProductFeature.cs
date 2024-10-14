using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }

        [Required, NotNull]
        public string FeatureName { get; set; }

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
