using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class ReceiptsService:IReceiptsService
    {
        private readonly IGenericRepository<Receipt> _repository;
       
        public ReceiptsService(IGenericRepository<Receipt> repository)                    
        {
            _repository = repository;
        }

        public async Task<ResultDto> GetReceipts()
        {
            var res = await _repository.GetAllSelect<ReceiptDto>(x => new ReceiptDto
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                Calories=x.Products.Sum(prod=>(prod.Product.CaloriesValue*Convert.ToDecimal(prod.Count))),
                Products = x.Products.Select(prod => new ProductReceiptDto
                {
                    Count = prod.Count,
                    Measurment = prod.Measurment,
                    Product = new ProductDto
                    {
                        Id = prod.Product.Id,
                        CaloriesValue = prod.Product.CaloriesValue,
                        CategoryName = prod.Product.Category.Name,
                        Name = prod.Product.Name,
                        Carbohydrates = prod.Product.Carbohydrates,
                        Fats = prod.Product.Fats,
                        PhotoUrl = prod.Product.PhotoUrl,
                        Protein = prod.Product.Protein
                    }
                }).ToList()
            }, null, x => x.Products);
            return new CollectionResultDto<ReceiptDto>
            {
                Count = res.Count(),
                Data = res.ToList(),
                IsSuccessful=true
            };
        }
    }
}