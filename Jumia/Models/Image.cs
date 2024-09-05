using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required, StringLength(50), NotNull]
        public string ImageName { get; set; }

        [Required, StringLength(200), NotNull]
        public string ImageURL { get; set; }

        // Common fields for CreatedBy, CreatedAt, UpdatedBy, UpdatedAt
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related Brand entities (one-to-many relationship)
        public virtual ICollection<Brand> Brands { get; set; }

        // Navigation property for related Department entities (one-to-many relationship)
        public virtual ICollection<Department>? Departments { get; set; }

        // Navigation property for related Category entities (one-to-many relationship)
        public virtual ICollection<Category>? Categories { get; set; }

        // Navigation property for related SubCategory entities (one-to-many relationship)
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
