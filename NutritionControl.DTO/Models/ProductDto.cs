using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DTO.Models
{
    public class ProductDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal CaloriesValue { get; set; }
        public decimal Protein { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbohydrates { get; set; }
        public string CategoryName { get; set; }
    }
}