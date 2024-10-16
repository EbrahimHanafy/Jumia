using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class ProductRate
    {
        [Key]
        public int ProductRateId { get; set; }

        [Required(ErrorMessage = "Please select a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rate { get; set; }

        [StringLength(250, ErrorMessage = "Review cannot be longer than 250 characters")]
        [MinLength(10, ErrorMessage = "Review must be at least 10 characters long")]
        public string? Review { get; set; }

        // Foreign key to Product
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
        public virtual Product? Product { get; set; }
    }
}