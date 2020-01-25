using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DTO.Models.Auth
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
