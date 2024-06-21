﻿using System.ComponentModel.DataAnnotations;

namespace KhumaloCrafting___.Models
{
    public class LoginModel
    {
        public class InputModel {

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

    }
}
