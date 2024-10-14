using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Jumia.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        [Required, NotNull]
        public int Quantity { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // Foreign key Product
        [Required]
        public int ProductId { get; set; }
        // Foreign key User
        [Required]
        public int UserCode { get; set; }
        // Foreign key ProductColorSize
        [Required]
        public int ProductColorSizeId { get; set; }
        //.........................................................
        // Navigation property for the related Product
        public virtual Product Product { get; set; }
        // Navigation property for the related User
        public virtual User User { get; set; }
        // Navigation property for the related ProductColorSize
        public virtual ProductColorSize ProductColorSize { get; set; }

    }
}
