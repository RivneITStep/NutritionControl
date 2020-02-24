using System;

namespace NutritionControl.DTO.Models.Diary
{
	public class WaterValueDto
	{
		public int Id { get; set; }
		public decimal Value { get; set; }
		public DateTime DateOfMeasurement { get; set; }
	}
}