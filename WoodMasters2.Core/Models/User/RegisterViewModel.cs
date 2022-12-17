using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Core.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(85)]
        public string PlaceName { get; set; } = null!;
        [Required]
        [StringLength(56)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The {0} must be at least {2} characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Password and Confirmation string are not identical")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

    }
}
