using System;

namespace NutritionControl.DTO.Models.Diary
{
	public class WeightInfoDto
	{
		public int Id { get; set; }
		public decimal WeightValue { get; set; }
		public DateTime DateOfMeasurement { get; set; }
	}
}