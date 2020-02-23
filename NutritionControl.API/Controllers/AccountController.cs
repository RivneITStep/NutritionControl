using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;


namespace NutritionControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
    }
}