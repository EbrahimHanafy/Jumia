using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalAmount { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalDiscount { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 99.9"), AllowNull]
        public int DiscountPercentage { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalTax { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 99.9"), AllowNull]
        public int TaxPercentage { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double ShippingFees { get; set; }
        [StringLength(200),AllowNull]
        public string? Notes { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // Foreign key User
        [Required]
        //[ForeignKey("UserCode")]
        public int UserCode { get; set; }
        // Foreign key UserAddress
        [Required]
        public int UserAddressId { get; set; }
        // Foreign key OrderStatus
        [Required]
        public int OrderStatusId { get; set; }
        // Foreign key DiscountCoupon
        [AllowNull]
        public int? DiscountCouponId { get; set; }
        // Foreign key to Payment 
        public int PaymentId { get; set; }
        //...........................................................................
        // Navigation property for the related Orderstatus
        public virtual OrderStatus Orderstatus { get; set; }
        // Navigation property for the related Payment
        public virtual Payment payment { get; set; }
        // Navigation property for the related DiscountCoupon
        public virtual DiscountCoupon? DiscountCoupon { get; set; }
        // Navigation property for the related User
        public User?  User { get; set; }
        // Navigation property for the related UserAddress
        public UserAddress UserAddress { get; set; }
        // Navigation property for related OrderDetails entities (one-to-many relationship)
        public virtual ICollection<OrderDetails>  OrderDetails { get; set; }
    }
}
