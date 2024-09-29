using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class Return
    {
        [Key]
        public int ReturnId { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalAmount { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalDiscount { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 99.9"), AllowNull]
        public double DiscountPercentage { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalTax { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 99.9"), AllowNull]
        public double TaxPercentage { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double ShippingFees { get; set; }
        [StringLength(200),AllowNull]
        public string? Notes { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // Foreign key OrderStatus
        [Required]
        public int OrderStatusId { get; set; }
        // Foreign key User
        [Required]
        public int UserId { get; set; }
        // Foreign key UserAddress
        [Required]
        public int UserAddressSerial { get; set; }
        // Foreign key Refund
        [Required]
        public int RefundId { get; set; }
        //.........................................................................................
        // Navigation property for the related Orderstatus
        public virtual OrderStatus? OrderStatus { get; set; }
        // Navigation property for the related User
        public virtual User User { get; set; }          
        // Navigation property for the related UserAddress
        public virtual UserAddress? UserAddress { get; set; }
        // Navigation property for the related Refund
        public virtual Refund Refund { get; set; }
        // Navigation property for related ReturnDetails entities (one-to-many relationship)
        public virtual ICollection<ReturnDetails> ReturnDetails { get; set; }
    }
}
