using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace Jumia.Models
{
    public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }

        [StringLength(50), AllowNull]
        public string? Village { get; set; }

        [StringLength(100), AllowNull]
        public string? Street { get; set; }

        [StringLength(10), AllowNull]
        public string? BuildingNumber { get; set; }
        
        [AllowNull]
        public int? FloorNumber { get; set; }
        
        [AllowNull]
        public int? ApartmentNumber { get; set; }
        
        [Required]
        public bool IsDefault { get; set; }
        [Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
        // ForeignKey for User
        [Required]
        public string Id { get; set; }
        // ForeignKey for Country
        [Required]
        public int CountryId { get; set; }
        // ForeignKey for Governorate
        [Required]
        public int GovernorateId { get; set; }
        // ForeignKey for City
        [Required]
        public int CityId { get; set; }

        // Navigation property for the related User 
        public virtual User User { get; set; }
        // Navigation property for the related Country 
        public virtual Country Country { get; set; }
        // Navigation property for the related Governorate 
        public virtual Governorate Governorate { get; set; }
        // Navigation property for the related City 
        public virtual City City { get; set; }

        // Navigation property for related Order  entities (one-to-many relationship)
        public virtual ICollection<Order> Orders { get; set; }
        // Navigation property for related Return  entities (one-to-many relationship)
        public virtual ICollection<Return> Returns { get; set; }

    }
}