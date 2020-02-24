using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models.Diary;

namespace NutritionControl.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiaryController : ControllerBase
	{
		private readonly IDiaryService _diaryService;
		public DiaryController(IDiaryService diaryService)
		{
			_diaryService = diaryService;
		}

		#region WeightInfo

		[HttpGet("GetWeightInfos")]
		public async Task<ResultDto> GetWeightInfos(int userId)
		{
			try
			{
				return await _diaryService.GetWeightInfos(userId);
			}
			catch (Exception ex)
			{
				return new ResultDto
				{
					IsSuccessful = false,
					Message = ex.Message
				};
			}
		}

		[HttpPost("AddWeightInfo")]
		public async Task<ResultDto> AddWeightInfo(WeightInfoDto weightInfo, int userId)
		{
			try
			{
				return await _diaryService.AddWeightInfo(weightInfo, userId);
			}
			catch (Exception ex)
			{
				return new ResultDto
				{
					IsSuccessful = false,
					Message = ex.Message
				};
			}
		}

		#endregion

		#region WaterValue

		[HttpGet("GetWaterValues")]
		public async Task<ResultDto> GetWaterValues(int userId)
		{
			try
			{
				return await _diaryService.GetWaterValues(userId);
			}
			catch (Exception ex)
			{
				return new ResultDto
				{
					IsSuccessful = false,
					Message = ex.Message
				};
			}
		}

		[HttpPost("AddWaterValue")]
		public async Task<ResultDto> AddWaterValue(WaterValueDto waterValue, int userId)
		{
			try
			{
				return await _diaryService.AddWaterValue(waterValue, userId);
			}
			catch (Exception ex)
			{
				return new ResultDto
				{
					IsSuccessful = false,
					Message = ex.Message
				};
			}
		}

		#endregion
	}
}