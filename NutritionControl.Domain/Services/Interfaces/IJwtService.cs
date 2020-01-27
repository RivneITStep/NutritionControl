namespace NutritionControl.Domain.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, int userId);
    }
}
