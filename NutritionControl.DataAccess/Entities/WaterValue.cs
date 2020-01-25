using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class WaterValue : IBaseEntity
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DateOfMeasurement { get; set; }

        /* Navigation Properties */

        public int UserId { get; set; }
        public User User { get; set; }
    }
}