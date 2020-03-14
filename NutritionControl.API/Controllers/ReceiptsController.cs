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
    public class ReceiptsController : ControllerBase
    {
        private readonly IReceiptsService _receiptsService;
        public ReceiptsController(IReceiptsService receiptsService)
        {
            _receiptsService = receiptsService;
        }
        [HttpGet]
        public async Task<ResultDto> GetReceipts()
        {
            try
            {
                return await _receiptsService.GetReceipts();
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong"
                };
            }
        }
    }
}