using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, int userId, IList<string> roles);
        Task<string> GenerateRefreshToken(int userId);
    }
}