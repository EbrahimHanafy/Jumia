
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Jumia.Models
{

    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please enter this field"), MaxLength(45)]
        public string CityName { get; set; }
        [Required,NotNull]
        public int CreatedBy { get; set; }
        [Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // ForeignKey for Governorate
        public int GovernorateId { get; set; }
        // Navigation property for the related Governorate 
        public virtual Governorate Governorate { get; set; }
        // Navigation property for related UserAddress entities(one-to-many relationship)
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}