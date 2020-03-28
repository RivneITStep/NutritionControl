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
    public class ProductsService : IProductsService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IAuthService _authService;

        public ProductsService(IGenericRepository<Product> repository,
                               IGenericRepository<Category> categoryRepository,
                               IAuthService authService)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _authService = authService;
        }

        public async Task<ResultDto> Add(ProductDto model)
        {
            try
            {
                var product = new Product
                {
                    CaloriesValue = model.CaloriesValue,
                    Carbohydrates = model.Carbohydrates,
                    Protein = model.Protein,
                    Name = model.Name,
                    Fats = model.Fats,
                    PhotoUrl = model.PhotoUrl,
                    Category = await _categoryRepository.GetSingle(x => x.Name == model.CategoryName) ??
                               new Category { Name = model.CategoryName }
                };

                await _repository.Create(product);
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

        public async Task<ResultDto> Edit(ProductDto model)
        {
            var product = await _repository.Find(model.Id);

            if (product == null)
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Error"
                };

            product.CaloriesValue = model.CaloriesValue;
            product.Carbohydrates = model.Carbohydrates;
            product.Protein = model.Protein;
            product.Fats = model.Fats;
            product.Name = model.Name;
            product.Category = await _categoryRepository.GetSingle(x => x.Name == model.CategoryName) ??
                               new Category { Name = model.CategoryName };

            await _repository.Update(product);

            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Edited"
            };
        }

        public async Task<ResultDto> Delete(int id)
        {
            var product = await _repository.Find(id);

            if (product == null)
                return new ResultDto
                {
                    IsSuccessful = false,
                    Message = "Error"
                };

            await _repository.Delete(product);
            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Product was successfully deleted"
            };
        }

        public async Task<PaginationResultDto<ProductDto>> GetProductsPaginated(int? page, int pageSize)
        {
            var count = await _repository.CountAll();

            var result = await _repository.GetPaged(page ?? 1, pageSize, (x => x.Name), (x => x.Category));

            return new PaginationResultDto<ProductDto>
            {
                IsSuccessful = true,
                Count = count,
                Data = result.Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhotoUrl = x.PhotoUrl,
                    Protein = x.Protein,
                    Fats = x.Fats,
                    CaloriesValue = x.CaloriesValue,
                    CategoryName = x.Category.Name,
                    Carbohydrates = x.Carbohydrates
                }).ToList(),
                PageIndex = page ?? 1,
                PageSize = pageSize
            };
        }

        public async Task<CollectionResultDto<ProductDto>> GetAllProducts()
        {
            //select * from products inner join category ...
            var result = await _repository.GetAllSelect(selector: x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                PhotoUrl = x.PhotoUrl,
                Protein = x.Protein,
                Fats = x.Fats,
                CaloriesValue = x.CaloriesValue,
                CategoryName = x.Category.Name,
                Carbohydrates = x.Carbohydrates
            }, includes: x => x.Category);

            return new CollectionResultDto<ProductDto>
            {
                Count = result.Count(),
                Data = result.ToList(),
                IsSuccessful = true,
                Message = "OK"
            };
        }

        public async Task<CollectionResultDto<GroupedProductDto>> GetGroupedProducts(int userId)
        {
            var products = await _repository.GetAllInclude(x => x.Category, x => x.ProductLikes);

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
                    Protein = prod.Protein,
                    IsLiked = prod.ProductLikes.FirstOrDefault(l => l.UserId == userId) != null
                }).ToList()
            }).ToList();

            return new CollectionResultDto<GroupedProductDto>
            {
                Count = grouped.Count(),
                Data = grouped,
                IsSuccessful = true
            };
        }

        public async Task<ResultDto> LikeProduct(int productId, int userId)
        {
            var product = await _repository.GetSingle(x => x.Id == productId, x => x.ProductLikes);

            var like = product.ProductLikes.FirstOrDefault(x => x.UserId == userId);
            if (like == null)
            {
                product.ProductLikes.Add(new ProductLike
                {
                    UserId = userId
                });

                await _repository.Update(product);

                return new ResultDto
                {
                    IsSuccessful = true,
                    Message = "Thanks for your Like"
                };
            }

            product.ProductLikes.Remove(like);

            await _repository.Update(product);

            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Disliked"
            };

        }
    }
}