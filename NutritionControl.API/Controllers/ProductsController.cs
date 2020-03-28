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
        private readonly IAuthService _authService;
        public ProductsController(IProductsService productsService,
                                  IAuthService authService)
        {
	        _productsService = productsService;
            _authService = authService;
        }

        [HttpGet("GetGrouped")]
        public async Task<ResultDto> GetGroupedProducts()
        {
            try
            {
                var userId = _authService.GetAuthorizedUserId();
                return await _productsService.GetGroupedProducts(userId);
            }
            catch (System.Exception)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong"
                };
            }
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

        [HttpGet("Like")]
        public async Task<ResultDto> LikeProduct(int productId)
        {
            try
            {
                var userId = _authService.GetAuthorizedUserId();
                return await _productsService.LikeProduct(productId, userId);
            }
            catch (System.Exception)
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