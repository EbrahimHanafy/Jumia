using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class ProductMaterialsCare
    {
        [Key]
        public Int64 ProductMaterialsCareId { get; set; }
                
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
        // Foreign key to MaterialsCare
        [Required]
        public int MaterialsCareId { get; set; }
        
        // Navigation property for the related Product
        public virtual Product Product { get; set; }
        // Navigation property for the related MaterialsCare
        public virtual MaterialsCare MaterialsCare { get; set; }
    }
}
