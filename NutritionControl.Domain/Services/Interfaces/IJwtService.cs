using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, int userId);
        Task<string> GenerateRefreshToken(int userId);
    }
}