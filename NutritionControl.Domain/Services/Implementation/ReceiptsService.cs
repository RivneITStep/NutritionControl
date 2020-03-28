using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly IGenericRepository<Receipt> _repository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<CategoryReceipt> _categoryRepository;

        public ReceiptsService(IGenericRepository<Receipt> repository,
                               IGenericRepository<CategoryReceipt> categoryRepository,
                               IGenericRepository<Product> productRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<ResultDto> GetReceipts()
        {
            var res = await _repository.GetAllSelect<ReceiptDto>(x => new ReceiptDto
            {
                Description = x.Description,
                Method = x.Method,
                Name = x.Name,
                Id = x.Id,
                Calories = x.Products.Sum(prod => (prod.Product.CaloriesValue * Convert.ToDecimal(prod.Count))),
                CategoryName = x.Category.Name,
                PhotoUrl = x.PhotoUrl,
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

        public async Task<ResultDto> GetReceipt(int id)
        {
            var receipt = await _repository.GetAllSelect<ReceiptDto>(x => new ReceiptDto
            {
                Description = x.Description,
                Method = x.Method,
                Name = x.Name,
                Id = x.Id,
                Calories = x.Products.Sum(prod => (prod.Product.CaloriesValue * Convert.ToDecimal(prod.Count))),
                CategoryName = x.Category.Name,
                PhotoUrl = x.PhotoUrl,
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
            }, x => x.Id == id, x => x.Products);
            if (receipt == null)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Wrong id"
                };
            }
            return new SingleResultDto<ReceiptDto>
            {
                IsSuccessful = true,
                Data = receipt.First()
            };
        }

        public async Task<ResultDto> Add(ReceiptDto model)
        {
            try
            {
                var receipt = new Receipt
                {
                    Id = model.Id,
                    Method=model.Method,
                    Name = model.Name,
                    Description = model.Description,
                    PhotoUrl = model.PhotoUrl,
                    Category = await _categoryRepository.GetSingle(x => x.Name == model.CategoryName) ??
                               new CategoryReceipt { Name = model.CategoryName },
                    Products = new List<ProductReceipt>()
                };
                for (int i = 0; i < model.Products.Count; i++)
                {
                    receipt.Products.Add(new ProductReceipt
                    {
                        Product = await _productRepository.GetSingle(x => x.Name == model.Products[i].Product.Name),
                        Measurment = model.Products[i].Measurment,
                        Count = model.Products[i].Count
                    });
                }
                await _repository.Create(receipt);
            }
            catch (Exception)
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
            if (receipt == null)
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
        public async Task<ResultDto> Edit(ReceiptDto model)
        {
            try
            {
                var receipt = await _repository.GetSingle(x => x.Id == model.Id, x => x.Products);
                if (receipt == null)
                {
                    return new ResultDto
                    {
                        IsSuccessful = false,
                        Message = "Error"
                    };
                }
                receipt.Name = model.Name;
                receipt.Method = model.Method;
                receipt.PhotoUrl = model.PhotoUrl;
                receipt.Description = model.Description;
                receipt.Category = await _categoryRepository.GetSingle(x => x.Name == model.CategoryName) ??
                                   new CategoryReceipt { Name = model.CategoryName };
                for (int i = 0; i < model.Products.Count; i++)
                {
                    if (receipt.Products.FirstOrDefault(x => x.ProductId == model.Products[i].Product.Id) == null)
                    {
                        receipt.Products.Add(new ProductReceipt
                        {
                            Product = await _productRepository.GetSingle(x => x.Name == model.Products[i].Product.Name),
                            Measurment = model.Products[i].Measurment,
                            Count = model.Products[i].Count
                        });
                    }
                }
                await _repository.Update(receipt);
                return new ResultDto
                {
                    IsSuccessful = true,
                    Message = "Receipt was succssfully updated"
                };
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
    }
}