using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class ReturnDetails
    {
        [Key]
        public int ReturnDetailsId { get; set; }
        [Required ,NotNull]
        public int Quantity { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double UnitPrice { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalPrice { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 9.99"), AllowNull]
        public double UnitDiscountPercentage { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double UnitDiscount { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalDiscount { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 9.99"), AllowNull]
        public double DiscountPercentage { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double UnitTax { get; set; }
        [DataType(DataType.Currency), Required, NotNull]
        public double TotalTax { get; set; }
        [Range(0, 99.9, ErrorMessage = "Please enter a value between 0 and 9.99"), AllowNull]
        public double TaxPercentage { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // Foreign key User
        [Required]
        public int ReturnId { get; set; }
        // Foreign key User
        [Required]
        public int  ProductId  { get; set; }

        // Navigation property for the related Retrun
        public virtual Retrun Return  { get; set; }
        // Navigation property for the related Product
        //public virtual Product Product { get; set; }


        
    }
}
