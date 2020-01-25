using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
    }
}