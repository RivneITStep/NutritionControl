using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;

namespace NutritionControl.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestProductsController : ControllerBase
    {
        private readonly ITestProductsService _testProductsService;
        public TestProductsController(ITestProductsService testProductsService)
        {
            _testProductsService = testProductsService;
        }

        [HttpGet]
        public async Task<CollectionResultDto<ProductDto>> GetProducts()
        {
            return await _testProductsService.GetAllProducts();
        }
    }
}