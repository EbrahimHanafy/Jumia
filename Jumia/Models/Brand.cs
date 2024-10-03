using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required, StringLength(50), NotNull]
        public string BrandName { get; set; }
        
        [AllowNull]
        public string? ImageURL { get; set; }

        // Common fields for CreatedBy, CreatedAt, UpdatedBy, UpdatedAt
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related Product entities (one-to-many relationship)
        public virtual ICollection<Product>? Products { get; set; }
    }
}
