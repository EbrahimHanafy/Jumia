using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;
namespace Jumia.Models
{
    public class Governorate
    {
        [Key]
        public int GovernorateId { get; set; }

        [Required(ErrorMessage = "Please enter this field"), MaxLength(60)]
        public string GovernorateName { get; set; }
        [Required,NotNull]
        public int CreatedBy { get; set; }
        [Required, NotNull]
        public DateTime CreatedAt { get; set; }
    
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // ForeignKey for Country
        public int CountryId { get; set; }
        // Navigation property for the related Country
        public virtual Country Country { get; set; }
        // Navigation property for related City entities (one-to-many relationship)
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        // Navigation property for related City entities (one-to-many relationship)
        public virtual ICollection<City> Cities { get; set; }

    }

}