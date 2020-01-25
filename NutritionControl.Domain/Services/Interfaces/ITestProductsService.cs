using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface ITestProductsService
    {
        Task<CollectionResultDto<ProductDto>> GetAllProducts();
    }
}
