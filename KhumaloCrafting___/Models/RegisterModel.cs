﻿using System.ComponentModel.DataAnnotations;

namespace KhumaloCrafting___.Models
{
    public class RegisterModel
    {

        public class InputModel {

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = " Confirm Password")]
            [Compare("Password", ErrorMessage = "Password does not match")]
            public string ConfirmPassword { get; set;}
        
        }
    }
}