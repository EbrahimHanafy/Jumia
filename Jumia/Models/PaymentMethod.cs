using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PyamentMethodId { get; set; }
        [StringLength(50),Required,NotNull]
        public string PyamentMethodName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        //..............................................
        // Navigation property for related Payment entities (one-to-many relationship)
        public virtual ICollection<Payment> Payments { get; set; }
        // Navigation property for related Refund entities (one-to-many relationship)
        public virtual ICollection<Refund> Refunds { get; set; }
    }
}
