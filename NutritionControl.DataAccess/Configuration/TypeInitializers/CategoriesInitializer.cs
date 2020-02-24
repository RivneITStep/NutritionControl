using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class CategoriesInitializer : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            Category[] categories = new Category[]
            {                
                new Category { Name = "Breads & Cereals"},
                new Category { Name = "Fish & Seafood"},
                new Category { Name = "Meat"},
                new Category { Name = "Confectionery"},
                new Category { Name = "Fruits & berries"},
                new Category { Name = "Nuts, Dried Fruits"},
                new Category { Name = "Vegetables" },
                new Category { Name = "Alcohol" },
            };

            await context.Set<Category>().AddRangeAsync(categories);
        }
    }
}
