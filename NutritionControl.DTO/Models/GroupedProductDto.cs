using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DTO.Models
{
    public class GroupedProductDto
    {
        public string CategoryName { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
