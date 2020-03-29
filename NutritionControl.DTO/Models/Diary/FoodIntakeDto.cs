using System;

namespace NutritionControl.DTO.Models.Diary
{
    public class FoodIntakeDto
    {
        public int Id { get; set; }
        public DateTime DateOfIntake { get; set; }
        public string Type { get; set; }
        public decimal FoodWeight { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}