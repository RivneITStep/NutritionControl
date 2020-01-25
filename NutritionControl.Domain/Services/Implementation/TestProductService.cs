using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class TestProductService : ITestProductsService
    {
        private readonly IGenericRepository<Product> _repository;

        public TestProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<CollectionResultDto<ProductDto>> GetAllProducts()
        {
            //select * from products inner join category ...
            var data = await _repository.GetAllInclude(x => x.Category);

            var result = data.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                PhotoUrl = x.PhotoUrl,
                Protein = x.Protein,
                Fats = x.Fats,
                CaloriesValue = x.CaloriesValue,
                CategoryName = x.Category.Name,
                Carbohydrates = x.Carbohydrates
            }).ToList();

            return new CollectionResultDto<ProductDto>
            {
                Count = result.Count(),
                Data = result,
                IsSuccessful = true,
                Message = "OK"
            };
        }
    }
}
