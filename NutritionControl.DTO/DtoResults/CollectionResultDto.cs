using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DTO.DtoResults
{
    public class CollectionResultDto<T> : ResultDto
    {
        public ICollection<T> Data { get; set; }
        public int Count { get; set; }
    }
}
