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
        [HttpGet("getReceipt")]
        public async Task<ResultDto> GetReceipt(int id)
        {
            try
            {
                return await _receiptsService.GetReceipt(id);
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = ex.ToString()
                };
            }
        }
        [HttpPost]
        public async Task<ResultDto> AddReceipt (ReceiptDto model)
        {
            return await _receiptsService.Add(model);
        }
        [HttpDelete]
        public async Task<ResultDto> DeleteReceipt(int id)
        {
            return await _receiptsService.Delete(id);
        }
        [HttpPut]
        public async Task<ResultDto> EditReceipt(ReceiptDto model)
        {
            return await _receiptsService.Edit(model);
        }
    }
}