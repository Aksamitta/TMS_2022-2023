using System.ComponentModel.DataAnnotations;

namespace Diplom_Game.Steam_Aksana.Patrubeika.ViewModel
{
    public class LoginViewModel
    {
        //можно сделать сделать авторизацию и по SteamName
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
