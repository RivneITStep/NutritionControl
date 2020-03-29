using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Diary;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Interfaces
{
	public interface IDiaryService
	{
        Task<ResultDto> GetFoodIntakes(FoodIntakeRequest request, int userId);
        Task<ResultDto> AddFoodIntake(FoodIntakeDto foodIntake, int userId);
        Task<ResultDto> AddWeightInfo(WeightInfoDto weightInfo, int userId);
		Task<ResultDto> GetWeightInfos(int userId);
		Task<ResultDto> AddWaterValue(WaterValueDto waterValue, int userId);
		Task<ResultDto> GetWaterValues(int userId);
	}
}