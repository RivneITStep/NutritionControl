using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NutritionControl.DataAccess.Entities;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.Domain.Utils;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthService(UserManager<User> userManager,
                           IJwtService jwtService,
                           SignInManager<User> signInManager,
						   IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _signInManager = signInManager;
			_httpContextAccessor = httpContextAccessor;
		}

		public int GetAuthorizedUserId()
		{
			return _httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>();
		}

        public async Task<ResultDto> Login(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsRemember, false);
            if (result.Succeeded)
            {
                var user = _userManager.Users.FirstOrDefault(r => r.Email == model.Email);
                var token = _jwtService.GenerateJwtToken(model.Email, user.Id);
                var refreshToken = await _jwtService.GenerateRefreshToken(user.Id);

                return new SingleResultDto<LoginResult>
                {
                    Data = new LoginResult
                    {
                        AccessToken = token,
                        RefreshToken = refreshToken
                    },
                    IsSuccessful = true,
                    Message = ""
                };
            }
            return new ResultDto
            {
                IsSuccessful = false,
                Message = "Wrong Email or Password"
            };
        }

        public async Task<ResultDto> Register(RegisterDto model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccessful = true,
                    Message = "User was succesfully registered"
                };
            }
            return new ResultDto
            {
                IsSuccessful = false,
                Message = AggregateIdentityErrors(result.Errors)
            };
        }

        private string AggregateIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            return identityErrors.Select(x => x.Code.ToString() + " " + x.Description + "\n").Aggregate((x, y) => x + y);
        }
    }
}