using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NutritionControl.DataAccess.Entities;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Auth;
using System;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        //private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
    
        public AuthService(UserManager<User> userManager,
                                IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public Task<ResultDto> Login(LoginDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto> Register(RegisterDto model)
        {
            //var user = new User
            //{
            //    Email = model.Email,
            //    UserName = model.Email
            //};
            //var result = await _userManager.CreateAsync(user, model.Password);
            //if (result.Succeeded)
            //{
            //    return await Login(new LoginDto { Email = model.Email, IsRemember = false, Password = model.Password });
            //}
            return null;
        }
    }
}
