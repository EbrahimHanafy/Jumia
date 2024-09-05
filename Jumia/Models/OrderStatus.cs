using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        [StringLength (45),Required, NotNull]
        public string Status { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        //.........................................................
        // Navigation property for related Order entities (one-to-many relationship)
        public virtual ICollection<Order> Orders { get; set; }
        // Navigation property for related Retrun entities (one-to-many relationship)
        public virtual ICollection<Retrun> Retruns { get; set; }
    }
}
