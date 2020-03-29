using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;

namespace NutritionControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPut]
        public async Task<ResultDto> EditCategory(CategoryDto category)
        {
            try
            {
                return await _categoriesService.Edit(category);
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong"
                };
            }
        }

        [HttpPost]
        public async Task<ResultDto> AddCategory(CategoryDto category)
        {
            try
            {
                return await _categoriesService.Add(category);
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong"
                };
            }
        }

        [HttpDelete]
        public async Task<ResultDto> DeleteCategory(int id)
        {
            try
            {
                return await _categoriesService.Delete(id);
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong"
                };
            }
        }


        [HttpGet]
        public async Task<ResultDto> GetCategories()
        {
            try
            {
                return await _categoriesService.GetCategories();
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong"
                };
            }
        }

        [HttpGet("Paged/{page}/{pageSize}")]
        public async Task<ResultDto> GetCategoriesPaginated(int page, int pageSize)
        {
            try
            {
                return await _categoriesService.GetCategoriesPaginated(page, pageSize);
            }
            catch (Exception)
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