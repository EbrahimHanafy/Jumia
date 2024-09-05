using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class DiscountCoupon
    {
        [Key]
        public int DiscountCouponId { get; set; }
        [StringLength(45),Required,NotNull]
        public string CouponCode { get; set; }
        [StringLength(45),Required,NotNull]
        public string CouponName { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 99.9"), NotNull]
        public double DiscountPercentage { get; set; }
        [Required]
        public bool IsStopped { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        //.....................................
        // Navigation property for related Order entities (one-to-many relationship)
        public virtual ICollection<Order> Orders { get; set; }

    }
}
