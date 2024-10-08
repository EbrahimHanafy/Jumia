using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required, StringLength(50), NotNull]
        public string DepartmentName { get; set; }
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

        // Navigation property for related Category entities (one-to-many relationship)
        public virtual ICollection<Category>? Categories { get; set; }
    }
}
