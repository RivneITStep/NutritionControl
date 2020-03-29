using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IGenericRepository<Category> _repository;
        public CategoriesService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Add(CategoryDto category)
        {
            var _category = new Category
            {
                Id = category.Id,
                Name = category.Name
            };

            await _repository.Create(_category);

            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Succesfully added"
            };
        }

        public async Task<ResultDto> Edit(CategoryDto category)
        {
            var _category = await _repository.Find(category.Id);

            _category.Name = category.Name;

            await _repository.Update(_category);

            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Succesfully edited"
            };
        }

        public async Task<ResultDto> Delete(int id)
        {
            var _category = await _repository.Find(id);

            if (_category != null)
                await _repository.Delete(_category);

            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Succesfully deleted"
            };
        }

        public async Task<ResultDto> GetCategories()
        {
            var res = await _repository.GetAllSelect(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                ProductsCount = x.Products.Count
            }, null, x => x.Products);

            return new CollectionResultDto<CategoryDto>
            {
                Count = res.Count(),
                Data = res.ToList(),
                IsSuccessful = true
            };
        }

        public async Task<PaginationResultDto<CategoryDto>> GetCategoriesPaginated(int? page, int pageSize)
        {
            var count = await _repository.CountAll();

            var result = await _repository.GetPaged(page ?? 1, pageSize, (x => x.Name), (x => x.Products));

            return new PaginationResultDto<CategoryDto>
            {
                IsSuccessful = true,
                Count = count,
                Data = result.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductsCount = x.Products.Count()
                }).ToList(),
                PageIndex = page ?? 1,
                PageSize = pageSize
            };
        }
    }
}