using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Interfaces
{
    public interface IEntityInitializer
    {
        Task SeedData();
        void AddConfig(ITypeInitializer typeInitializer);
    }
}