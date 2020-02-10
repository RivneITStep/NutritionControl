using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class AdditionalInfoInitializer : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            var user = await context.Set<User>().FirstOrDefaultAsync(x => x.Email == "vasyan@gmail.com");

            user.UserAdditionalInfo = new UserAdditionalInfo
            {
                Age = 23,
                GoalWeight = 70,
                Height = 173,
                Weight = 95,
                Name = "Vasyan",
                Surname = "Vasyanov",
                Gender = "Male"
            };
        }
    }
}
