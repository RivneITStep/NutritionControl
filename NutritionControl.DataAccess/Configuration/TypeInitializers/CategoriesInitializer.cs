using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class CategoriesInitializer : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            Category[] categories = new Category[]
            {
                new Category { Name = "Dairy Foods"},
                new Category { Name = "Vegetables"},
                new Category { Name = "Fruits" },
                new Category { Name = "Meat and Poultry"},
                new Category { Name = "Fish and Seafood" }
            };

            await context.Set<Category>().AddRangeAsync(categories);
        }
    }
}
