﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "*Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Password is required")]
        public string Password { get; set; }

        public bool RemeberMe { get; set; }
    }
}