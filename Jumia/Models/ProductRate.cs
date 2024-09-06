using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class ProductRate
    {
        [Key]
        public int ProductRateId { get; set; }

        [Range(0,5), Required, NotNull]
        public int Rate { get; set; }

        [StringLength(250), AllowNull]
        public string? Review { get; set; }

        [StringLength(50), AllowNull]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress), AllowNull]
        public string? Email { get; set; }
        
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
