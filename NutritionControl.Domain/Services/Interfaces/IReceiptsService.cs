using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IReceiptsService
    {
        Task<ResultDto> GetReceipts();
        Task<ResultDto> Add(ReceiptDto model);
        Task<ResultDto> Delete(int id);
    }
}