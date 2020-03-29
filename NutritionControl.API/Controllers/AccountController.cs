using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;

namespace NutritionControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthService _authService;
        public AccountController(IAccountService accountService, IAuthService authService)
        {
            _accountService = accountService;
            _authService = authService;
        }

        [HttpGet("GetProfile")]
        public async Task<ResultDto> GetProfile(int userId)
        {
            try
            {
                return await _accountService.GetProfile(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ResultDto> SaveProfile(ProfileDto profile)
        {
            try
            {
                var userId = _authService.GetAuthorizedUserId();
                return await _accountService.SaveProfile(profile, userId);
            }
            catch (Exception ex)
            {
                return new ResultDto { IsSuccessful = false, Message = ex.ToString() };
            }
        }
    }
}