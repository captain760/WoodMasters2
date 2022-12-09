﻿using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Core.Models.User
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

    }
}