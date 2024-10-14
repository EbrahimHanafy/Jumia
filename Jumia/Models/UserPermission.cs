using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;
using System.Diagnostics.CodeAnalysis;
using System.Data;

namespace Jumia.Models
{
    public class UserPermission
    {
        [Key]
        public int UserPermissionId { get; set; }
        // ForeignKey for Permission
        [Required]
        public int PermissionId { get; set; }
        // ForeignKey for User
        [Required]
        public int UserCode { get; set; }

        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]

        public DateTime? UpdatedAt { get; set; }

        // Navigation property for the related User
        public virtual User User { get; set; }
        // Navigation property for the related Permission
        public virtual Permission Permission { get; set; }
        // Common fields for CreatedBy, CreatedAt, UpdatedBy, UpdatedAt
    }
}
