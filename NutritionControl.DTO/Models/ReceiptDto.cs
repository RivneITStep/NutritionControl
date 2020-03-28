using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DTO.Models
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public decimal Calories { get; set; }
        public string CategoryName { get; set; }
        public string Method { get; set; }
        public List<ProductReceiptDto> Products { get; set; }
    }
    public class ProductReceiptDto
    {
        public double Count { get; set; }
        public string Measurment { get; set; }
        public ProductDto Product { get; set; }
    }
}