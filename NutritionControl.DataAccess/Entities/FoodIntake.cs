using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class FoodIntake : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime DateOfIntake { get; set; }
        public decimal CaloriesValue { get; set; }
        public string Description { get; set; }
        public decimal FoodWeight { get; set; }

        /* Navigation Properties */

        public int UserId { get; set; }
        public User User { get; set; }
    }
}