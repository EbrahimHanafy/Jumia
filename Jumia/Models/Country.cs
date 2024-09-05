using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{
    public class Country
    {

        public int CountryId { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }

        public int CountryCode { get; set; }

        public int PhoneLength { get; set; }

        [StringLength(45)]
        public string CurrencyName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}