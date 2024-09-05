
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{
 public class User
    {
        public Int64  UserId { get; set; } 

        [StringLength(50)]
        public string UserName { get; set; }

        public int UserType { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string ImageURL { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public char Gender { get; set; } // محطوطه فالداتا بيز int

        public bool IsActive { get; set; }

        [StringLength(45)]
        public string Phone1 { get; set; }

        [StringLength(45)]
        public string Phone2 { get; set; }

        public int RoleId { get; set; }

        public int DisclaimerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

       
        //public virtual Role Role { get; set; }
    }
 //دول هيتحطوا فال DB context class 
    //public DbSet<User> Users { get; set; }
    //public DbSet<Role> Roles { get; set; }
    //public DbSet<UserAddress> UserAddresses { get; set; }
    //public DbSet<City> Cities { get; set; }
    //public DbSet<Governorate> Governorates { get; set; }
    //public DbSet<Country> Countries { get; set; }
    //public DbSet<WishList> WishLists { get; set; }
    //public DbSet<Disclaimer> Disclaimers { get; set; }

}