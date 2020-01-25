using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DTO.DtoResults
{
    public class SingleResultDto<T> : ResultDto
    {
        public T Data { get; set; }
    }
}
