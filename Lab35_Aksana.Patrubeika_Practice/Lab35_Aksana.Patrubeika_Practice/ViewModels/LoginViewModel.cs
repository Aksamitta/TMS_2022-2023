﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab35_Aksana.Patrubeika_Practice.ViewModels
{
    public class LoginViewModel
    {
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
