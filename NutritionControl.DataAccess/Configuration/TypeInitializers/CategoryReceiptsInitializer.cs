using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class CategoryReceiptsInitializer: ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            CategoryReceipt[] categoryReceipts = new CategoryReceipt[]
            {
                new CategoryReceipt { Name = "Soups"},
                new CategoryReceipt { Name = "Salads"},
                new CategoryReceipt { Name = "Desserts"},
                new CategoryReceipt { Name = "Meat dishes"},
                new CategoryReceipt { Name = "Fish dishes"},
                new CategoryReceipt { Name = "Side dishes"},
                new CategoryReceipt { Name = "Drinks" }
            };

            await context.Set<CategoryReceipt>().AddRangeAsync(categoryReceipts);
        }
    }
}
