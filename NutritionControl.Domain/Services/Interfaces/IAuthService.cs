using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Auth;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResultDto> Register(RegisterDto entity);
        Task<ResultDto> Login(LoginDto entity);
    }
}