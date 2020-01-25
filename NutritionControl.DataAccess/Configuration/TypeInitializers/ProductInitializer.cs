using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class ProductsInitializer : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            Product[] products = new Product[]
            {
                new Product 
                { 
                    Name = "Moloko",
                    CaloriesValue = 322,
                    Carbohydrates = 92,
                    Protein = 33,
                    Fats = 543,
                    PhotoUrl = "PHOTO_URL",
                    Category = await context.Set<Category>().FirstOrDefaultAsync(x=>x.Name == "Dairy Foods")
                },
                new Product
                {
                    Name = "Kartoshka",
                    CaloriesValue = 322,
                    Carbohydrates = 92,
                    Protein = 33,
                    Fats = 543,
                    PhotoUrl = "PHOTO_URL",
                    Category = await context.Set<Category>().FirstOrDefaultAsync(x=>x.Name == "Vegetables")
                },
                new Product
                {
                    Name = "Yabluko",
                    CaloriesValue = 322,
                    Carbohydrates = 92,
                    Protein = 33,
                    Fats = 543,
                    PhotoUrl = "PHOTO_URL",
                    Category = await context.Set<Category>().FirstOrDefaultAsync(x=>x.Name == "Fruits")
                },
                new Product
                {
                    Name = "Kurka",
                    CaloriesValue = 322,
                    Carbohydrates = 92,
                    Protein = 33,
                    Fats = 543,
                    PhotoUrl = "PHOTO_URL",
                    Category = await context.Set<Category>().FirstOrDefaultAsync(x=>x.Name == "Meat and Poultry")
                },
                new Product
                {
                    Name = "Losos",
                    CaloriesValue = 322,
                    Carbohydrates = 92,
                    Protein = 33,
                    Fats = 543,
                    PhotoUrl = "PHOTO_URL",
                    Category = await context.Set<Category>().FirstOrDefaultAsync(x=>x.Name == "Fish and Seafood")
                }
            };

            await context.Set<Product>().AddRangeAsync(products);
        }
    }
}
