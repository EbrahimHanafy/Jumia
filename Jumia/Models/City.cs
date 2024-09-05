
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{

    public class City
    {
        // [Key]
        public int CityId { get; set; }

        [StringLength(45)]
        public string CityName { get; set; }

        public int CreatedBy { get; set; }

       // public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

       // public DateTime? UpdatedAt { get; set; }

        public int GovernorateId { get; set; }

       // [ForeignKey("GovernorateId")]
        //public virtual Governorate Governorate { get; set; }
    }
}