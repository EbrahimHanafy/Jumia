using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;
namespace Jumia.Models
{

    public class WishList
    {
        [Key]
        public int WishListId { get; set; }

        [Required, NotNull]
        public int CreatedBy { get; set; }
        [Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // ForeignKey for User
        public int UserId { get; set; }
        // ForeignKey for Product 
        public int ProductId { get; set; }
        
        // Navigation property for the related Product
        //public virtual Product Product { get; set; }

        // Navigation property for the related User
        public virtual User User { get; set; }
    }
}