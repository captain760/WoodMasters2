using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Core.Models.User
{
    public class LoginViewModel
    {
        [Required]
        
        public string UserName { get; set; } = null!;

        [Required]
       
        public string Password { get; set; } = null!;

    }
}
