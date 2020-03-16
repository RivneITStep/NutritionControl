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
    public class ReceiptsService : IReceiptsService
    {
        private readonly IGenericRepository<Receipt> _repository;
        private readonly IGenericRepository<CategoryReceipt> _categoryRepository;

        public ReceiptsService(IGenericRepository<Receipt> repository,
                               IGenericRepository<CategoryReceipt> categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultDto> GetReceipts()
        {
            var res = await _repository.GetAllSelect<ReceiptDto>(x => new ReceiptDto
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                Calories = x.Products.Sum(prod => (prod.Product.CaloriesValue * Convert.ToDecimal(prod.Count))),
                CategoryName = x.Category.Name,
                PhotoUrl=x.PhotoUrl,
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
                IsSuccessful = true
            };
        }
        public async Task<ResultDto> Add(ReceiptDto model)
        {
            try
            {
                var receipt = new Receipt
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Category = await _categoryRepository.GetSingle(x => x.Name == model.CategoryName) ??
                               new CategoryReceipt { Name = model.CategoryName }
                };
                await _repository.Create(receipt);
            }
            catch(Exception)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Error"
                };
            }

            return new ResultDto
            {
                IsSuccessful = true
            };
        }
        public async Task<ResultDto> Delete(int id)
        {
            var receipt = await _repository.Find(id);
            if(receipt==null)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Error"
                };
            }
            await _repository.Delete(receipt);
            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Receipt was successfully deleted"
            };
        }
    }
}
