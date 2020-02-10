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
    public class ProductsService : IProductsService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductsService(IGenericRepository<Product> repository)
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

        public async Task<CollectionResultDto<GroupedProductDto>> GetGroupedProducts()
        {
            var products = await _repository.GetAllInclude(x => x.Category);

            var grouped = products.GroupBy(x => x.Category.Name).Select(x => new GroupedProductDto
            {
                CategoryName = x.Key,
                Products = x.Select(prod => new ProductDto
                {
                    Id = prod.Id,
                    CaloriesValue = prod.CaloriesValue,
                    CategoryName = prod.Category.Name,
                    Name = prod.Name,
                    Carbohydrates = prod.Carbohydrates,
                    Fats = prod.Fats,
                    PhotoUrl = prod.PhotoUrl,
                    Protein = prod.Protein
                }).ToList()
            }).ToList();

            return new CollectionResultDto<GroupedProductDto>
            {
                Count = grouped.Count(),
                Data = grouped,
                IsSuccessful = true
            };
        }
    }
}