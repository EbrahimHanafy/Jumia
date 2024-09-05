using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{
    public class Governorate
    {
        //[Key]
        public int GovernorateId { get; set; }

        [StringLength(60)]
        public string GovernorateName { get; set; }

        public int CreatedBy { get; set; }

      //  public DateTime CreatedAt { get; set; }

        public int CountryId { get; set; }

        public int? UpdatedBy { get; set; }

       // public DateTime? UpdatedAt { get; set; }

        //[ForeignKey("CountryId")]
        //public virtual Country Country { get; set; }
    }

}