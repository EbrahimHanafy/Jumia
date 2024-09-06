using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required, StringLength(50), NotNull]
        public string ColorName { get; set; }

        // Common fields shared across all tables
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related ProductColorSize entities (one-to-many relationship)
        public virtual ICollection<ProductColorSize> ProductColorSize { get; set; }
    }
}
