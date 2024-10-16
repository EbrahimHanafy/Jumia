using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;
namespace Jumia.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        
        [Required(ErrorMessage = "Please enter this field"), MaxLength(50)]
        public string CountryName { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public int PhoneLength { get; set; }

    //    [Required(ErrorMessage = "Please enter this field"), MaxLength(45)]
        public string CountryFlag { get; set; }
        [Required,NotNull]
        public int CreatedBy { get; set; }
        [Required,NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // Navigation property for related UserAddress entities (one-to-many relationship)
        public virtual ICollection<UserAddress> UserAddresses { get; set;}
        // Navigation property for related Governorate entities (one-to-many relationship)
        public virtual ICollection<Governorate> Governorates { get; set; }

    }
}