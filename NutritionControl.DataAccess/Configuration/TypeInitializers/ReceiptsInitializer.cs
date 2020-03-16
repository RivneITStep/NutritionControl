using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class ReceiptsInitializer:ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            Receipt r = new Receipt
            {
                Description = "sdffdsf",
                Name = "Soup z kartohi",
                Products = new List<ProductReceipt>()
            };
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x=>x.Name=="Potato"),
                Count=5,
                Measurment="gr"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Carrot"),
                Count = 1,
                Measurment = "gr"
            });
            await context.Set<Receipt>().AddAsync(r);
        }
    }
}
