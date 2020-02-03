using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class User : IdentityUser<int>,IBaseEntity
    {
        public User()
        {
            WeightInfos = new HashSet<WeightInfo>();
            WaterValues = new HashSet<WaterValue>();
            FoodIntakes = new HashSet<FoodIntake>();
        }

        /* Navigation Properties */

        public int? RefreshTokenId { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public int? UserAdditionalInfoId { get; set; }
        public UserAdditionalInfo UserAdditionalInfo { get; set; }
        public ICollection<WeightInfo> WeightInfos { get; set; }
        public ICollection<WaterValue> WaterValues { get; set; }
        public ICollection<FoodIntake> FoodIntakes { get; set; }
    }
}