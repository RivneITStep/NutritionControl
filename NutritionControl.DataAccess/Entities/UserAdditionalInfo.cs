using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class UserAdditionalInfo : IBaseEntity
    {
        public int Id { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? Age { get; set; }
        public decimal? BMI { get; set; }
        public decimal? GoalWeight { get; set; }

        /* Navigation Properties */

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}