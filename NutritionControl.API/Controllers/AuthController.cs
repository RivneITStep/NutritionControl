using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Auth;

namespace NutritionControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ResultDto> Register([FromBody] RegisterDto model)
        {
            try
            {
                return await _authService.Register(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ResultDto> Login([FromBody] LoginDto model)
        {
            try
            {
                return await _authService.Login(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}