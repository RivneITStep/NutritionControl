using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IProductsService
    {
        Task<CollectionResultDto<ProductDto>> GetAllProducts();
        Task<CollectionResultDto<GroupedProductDto>> GetGroupedProducts();
        Task<ResultDto> Delete(int id);
        Task<ResultDto> Edit(ProductDto model);
        Task<PaginationResultDto<ProductDto>> GetProductsPaginated(int? page, int pageSize);
    }
}