
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Jumia.ViewModels;
namespace Jumia.Models
{
    public class User : IdentityUser
    {
        //[Key]
        // public string  UserId { get; set; } 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserCode { get; set; }
        //[Required(ErrorMessage = "Please enter this field"), MaxLength(50)]
        //public string UserName { get; set; }

        //[Required(ErrorMessage = "Please enter this field")] 
        //public int UserType { get; set; }

        //[Required(ErrorMessage = "Please enter this field"), MaxLength(200)]
        //public string Password { get; set; }

        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Please enter this field"), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter this field"), MaxLength(50)]
        public string LastName { get; set; }

        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter this field")]
        public DateTime DateOfBirth { get; set; }

         [Required(ErrorMessage = "Please enter this field")]
        public Gender Gender { get; set; }
       
        public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Please enter this field"), MaxLength(45)]
        //public string Phone1 { get; set; }

        //[MaxLength(45)]
        //public string? Phone2 { get; set; }
        [Required, NotNull]
        public int CreatedBy { get; set; }
        [Required, NotNull]
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public int? UpdatedBy { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related Order entities (one-to-many relationship)
        public virtual ICollection<Order> Orders{ get; set; }
        // Navigation property for related WishList entities (one-to-many relationship)
        public virtual ICollection<WishList> WishLists { get; set; }
        // Navigation property for related UserAddresses entities (one-to-many relationship)
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        // Navigation property for related ShoppingCart  entities (one-to-many relationship)
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        // Navigation property for related Return  entities (one-to-many relationship)
        public virtual ICollection<Return> Returns { get; set; }
        // Navigation property for related Return  entities (one-to-many relationship)
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }  
}