using NutritionControl.DTO.DtoResults;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IReceiptsService
    {
        Task<ResultDto> GetReceipts();
    }
}