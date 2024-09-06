using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class Refund
    {
        [Key]
        public int RefundId { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double  RefundAmount { get; set; }
        public string? CreditCardNumber { get; set; }
        [DataType(DataType.Date), AllowNull]    
        public DateOnly? CreditCardExpDate { get; set; }
        [StringLength(80), Required, AllowNull]
        public string? CardHolderName { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // Foreign key PaymentMethod
        [Required]
        public int PaymentMethodId { get; set; }
        //...............................................
        // Navigation property for the related Payment
        public virtual PaymentMethod PaymentMethod { get; set; }
        // Navigation property for related Retrun entities (one-to-many relationship)
        public virtual ICollection<Return> Returns { get; set; }
    }
}
