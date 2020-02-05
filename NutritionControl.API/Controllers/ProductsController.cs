using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;

namespace NutritionControl.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _testProductsService;
        public ProductsController(IProductsService testProductsService)
        {
            _testProductsService = testProductsService;
        }

        [HttpGet("GetGrouped")]
        public async Task<CollectionResultDto<GroupedProductDto>> GetGroupedProducts()
        {
            return await _testProductsService.GetGroupedProducts();
        }

        [HttpGet]
        public async Task<CollectionResultDto<ProductDto>> GetProducts()
        {
            return await _testProductsService.GetAllProducts();
        }
    }
}