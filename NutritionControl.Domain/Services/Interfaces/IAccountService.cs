using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResultDto> SaveProfile(ProfileDto profile, int userId);
        Task<ResultDto> GetProfile(int userId);
    }
}