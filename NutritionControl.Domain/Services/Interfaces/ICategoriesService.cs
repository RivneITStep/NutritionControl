using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<ResultDto> GetCategories();
        Task<PaginationResultDto<CategoryDto>> GetCategoriesPaginated(int? page, int pageSize);
        Task<ResultDto> Edit(CategoryDto category);
        Task<ResultDto> Add(CategoryDto category);
        Task<ResultDto> Delete(int id);
    }
}
