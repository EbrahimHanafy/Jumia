using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{

    public class WishList
    {

        public Int64 WishListId { get; set; }

        public int ProductId { get; set; }

        public Int64 UserId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties

        //public virtual Product Product { get; set; }


        //public virtual User User { get; set; }
    }
}