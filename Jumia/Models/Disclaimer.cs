
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;
namespace Jumia.Models
{

    public class Disclaimer
    {
          [Key]
        public int DisclaimerId { get; set; }

        [Required(ErrorMessage = "Please enter this field"), MaxLength(500)]

        public string DisclaimerText { get; set; }

        [Required, NotNull]
        public int CreatedBy { get; set; }
        [Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation property for related User  entities (one-to-many relationship)
        public virtual ICollection<User> Users { get; set; }
    }
}