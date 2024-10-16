using System.ComponentModel.DataAnnotations;

namespace Jumia.ViewModels
{
    public enum Gender
    {
        Male , Female
    }
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter Username"), MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter First"), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter LAst"), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter this field"), MaxLength(45)]
        public string Phone1 { get; set; }

        [MaxLength(45)]
        public string? Phone2 { get; set; }


        [Required(ErrorMessage = "Please enter Your Gender")]
        public Gender Gender { get; set; }
    }

}
