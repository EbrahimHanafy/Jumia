using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class MaterialsCare
    {
        [Key]
        public int MaterialsCareId { get; set; }
        
        [StringLength(150),Required, NotNull]
        public string MaterialsCareName { get; set; }
        
        [StringLength(50), Required, NotNull]
        public string MaterialsCareIcon { get; set; }
        
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related ProductMaterialsCare entities (one-to-many relationship)
        public virtual ICollection<ProductMaterialsCare> ProductMaterialsCares { get; set; }
    }
}
