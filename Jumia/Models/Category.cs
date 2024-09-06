using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace YourProjectNamespace.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(50), NotNull]
        public string CategoryName { get; set; }

        // Common fields for CreatedBy, CreatedAt, UpdatedBy, UpdatedAt
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Foreign Key to Image
        [AllowNull]
        public int? ImageId { get; set; }

        // Foreign Key to Image
        [Required]
        public int DepartmentId { get; set; }


        // Navigation property for the related Image
        public virtual Image? Image { get; set; }

        // Navigation property for the related Department
        public virtual Department Department { get; set; }

        // Navigation property for related SubCategory entities (one-to-many relationship)
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
