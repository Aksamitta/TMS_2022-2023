using System.ComponentModel.DataAnnotations;

namespace Diplom_Game.Steam_Aksana.Patrubeika.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string SteamName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
