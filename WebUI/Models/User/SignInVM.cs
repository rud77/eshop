﻿using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.User
{
    public class SignInVM
    {
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}