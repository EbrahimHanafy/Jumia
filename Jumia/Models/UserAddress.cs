using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{
    public class UserAddress
    {
        //[Key]
        public int UserAddressId { get; set; }

        public int UserId { get; set; }

        public int CountryId { get; set; }

        public int GovernorateId { get; set; }

        public int CityId { get; set; }

        [StringLength(50)]
        public string Village { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(10)]
        public string BuildingNumber { get; set; }

        public int FloorNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public bool IsDefault { get; set; }

        // [ForeignKey("CountryId")]
        //public virtual Country Country { get; set; }
        // [ForeignKey("GovernorateId")]
        //public virtual Governorate Governorate { get; set; }
        //[ForeignKey("CityId")]
        //public virtual City City { get; set; }
    }
}