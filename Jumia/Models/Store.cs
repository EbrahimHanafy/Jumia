using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

// Author: Khaled Ahmed
namespace Jumia.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [StringLength(50), Required, NotNull]
        public string StoreName { get; set; }
        
        [Required, NotNull]
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime), Required, NotNull]
        public DateTime CreatedAt { get; set; }

        [AllowNull]
        public int? UpdatedBy { get; set; }

        [DataType(DataType.DateTime), AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related ProductInStore entities (one-to-many relationship)
        public virtual ICollection<ProductInStore> ProductInStores { get; set; }
    }
}
