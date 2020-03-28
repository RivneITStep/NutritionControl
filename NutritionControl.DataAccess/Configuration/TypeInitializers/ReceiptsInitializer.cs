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
            var categorySoups = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Soups");
            var categorySalads = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Salads");
            var categoryMeat = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Meat dishes");
            var categoryFish = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Fish dishes");
            var categoryDesserts = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Desserts");
            var categorySide = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Side dishes");
            var categoryDrinks = await context.Set<CategoryReceipt>().FirstOrDefaultAsync(x => x.Name == "Drinks");

            //Receipt r = new Receipt
            //{
            //    Description = "This dish has less than 400 calories per serve & you can make it in 30 minutes from scratch, which makes it a great after work dinner for the family or dinner party.",
            //    Name = "Spanish Fish Stew",
            //    Category= categoryFish,
            //    PhotoUrl= "http:////www.weightloss.com.au/assets/Uploads/Recipes/spanish-fish-stew-lge.jpg",
            //    Products = new List<ProductReceipt>()
            //};
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x=>x.Name== "Cod"),
            //    Count=400,
            //    Measurment="g"
            //});
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Tomato"),
            //    Count = 8,
            //    Measurment = "g"
            //});
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Onion"),
            //    Count = 1,
            //    Measurment = "g"
            //});
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Green peas"),
            //    Count = 100,
            //    Measurment = "g"
            //});
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "White wine"),
            //    Count = 150,
            //    Measurment = "ml"
            //});
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Carrot"),
            //    Count = 2,
            //    Measurment = "g"
            //});
            //r.Products.Add(new ProductReceipt
            //{
            //    Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Potato"),
            //    Count = 150,
            //    Measurment = "ml"
            //});
            //await context.Set<Receipt>().AddAsync(r);
            Receipt r1 = new Receipt
            {
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu sem integer vitae justo eget magna fermentum.",
                Name = "Soup z banana",
                Category = categorySoups,
                PhotoUrl = "test.jpg",
                Products = new List<ProductReceipt>()
            };
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Potato"),
                Count = 5,
                Measurment = "gr"
            });
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Banana"),
                Count = 1,
                Measurment = "gr"
            });
            await context.Set<Receipt>().AddAsync(r1);
        }
    }
}
