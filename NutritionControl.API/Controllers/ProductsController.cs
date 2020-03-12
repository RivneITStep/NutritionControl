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
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
	        _productsService = productsService;
        }

        [HttpGet("GetGrouped")]
        public async Task<CollectionResultDto<GroupedProductDto>> GetGroupedProducts()
        {
            return await _productsService.GetGroupedProducts();
        }

        [HttpGet]
        public async Task<CollectionResultDto<ProductDto>> GetProducts()
        {
            return await _productsService.GetAllProducts();
        }

        [HttpGet("Paged/{page}/{pageSize}")]
        public async Task<PaginationResultDto<ProductDto>> GetProductsPaged(int page,int pageSize)
        {
	        return await _productsService.GetProductsPaginated(page, pageSize);
        }

        [HttpPost]
        public async Task<ResultDto> AddProduct(ProductDto model)
        {
	        return await _productsService.Add(model);
        }

		[HttpDelete]
        public async Task<ResultDto> DeleteProduct(int id)
        {
	        return await _productsService.Delete(id);

        }

        [HttpPut]
        public async Task<ResultDto> EditProduct(ProductDto model)
        {
	        return await _productsService.Edit(model);
        }
	}
}