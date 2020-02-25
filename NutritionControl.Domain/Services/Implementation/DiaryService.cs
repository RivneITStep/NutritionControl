using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Diary;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
	public class DiaryService : IDiaryService
	{
		private readonly IGenericRepository<WeightInfo> _weightRepository;
		private readonly IGenericRepository<WaterValue> _waterRepository;

		public DiaryService(IGenericRepository<WeightInfo> weightRepository,
							IGenericRepository<WaterValue> waterRepository)
		{
			_weightRepository = weightRepository;
			_waterRepository = waterRepository;
		}

		#region WeightInfo

		public async Task<ResultDto> AddWeightInfo(WeightInfoDto weightInfo, int userId)
		{
			try
			{
				await _weightRepository.Create(new WeightInfo
				{
					DateOfMeasurement = weightInfo.DateOfMeasurement,
					UserId = userId,
					WeightValue = weightInfo.WeightValue
				});
				return new ResultDto
				{
					IsSuccessful = true,
					Message = "Weight info was added"
				};
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public async Task<ResultDto> GetWeightInfos(int userId)
		{
			var weightInfos = await _weightRepository.GetAllSelect<WeightInfoDto>(x => new WeightInfoDto
			{
				DateOfMeasurement = x.DateOfMeasurement,
				Id = x.Id,
				WeightValue = x.WeightValue
			}, x => x.UserId == userId);

			var result = weightInfos.OrderBy(x => x.DateOfMeasurement).ToList();

			return new CollectionResultDto<WeightInfoDto>
			{
				Count = result.Count(),
				Data = result,
				IsSuccessful = true
			};
		}

		#endregion

		#region WaterValue

		public async Task<ResultDto> AddWaterValue(WaterValueDto waterValue, int userId)
		{
			try
			{
				await _waterRepository.Create(new WaterValue
				{
					DateOfMeasurement = waterValue.DateOfMeasurement,
					UserId = userId,
					Value = waterValue.Value
				});
				return new ResultDto
				{
					IsSuccessful = true,
					Message = "Water value was added"
				};
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public async Task<ResultDto> GetWaterValues(int userId)
		{
			var waterValues = await _waterRepository.GetAllSelect<WaterValueDto>(x => new WaterValueDto
			{
				DateOfMeasurement = x.DateOfMeasurement,
				Id = x.Id,
				Value = x.Value
			}, x => x.UserId == userId);

			var result = waterValues.GroupBy(x => x.DateOfMeasurement.ToShortDateString()).Select(x => new WaterValueDto
			{
				Value = x.Sum(w => w.Value),
				DateOfMeasurement = DateTime.Parse(x.Key),
				Id = 0
			}).OrderBy(x => x.DateOfMeasurement).ToList();

			return new CollectionResultDto<WaterValueDto>
			{
				Count = result.Count(),
				Data = result,
				IsSuccessful = true
			};
		}

		#endregion
	}
}