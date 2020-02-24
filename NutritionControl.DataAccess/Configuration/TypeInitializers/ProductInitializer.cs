using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class ProductsInitializer : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            var categoryVeg = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Vegetables");
            var categoryBreads = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Breads & Cereals");
            var categoryMeat = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Meat");
            var categoryFish = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Fish & Seafood");
            var categoryFruits = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Fruits & berries");
            var categoryNuts = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Nuts, Dried Fruits");
            var categoryConf = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Confectionery");
            var categoryAlc = await context.Set<Category>().FirstOrDefaultAsync(x => x.Name == "Alcohol");

            Product[] products = new Product[]
            {
                #region init Vegetables
                new Product 
                { 
                    Name = "Aubergine",
                    CaloriesValue = 25,
                    Carbohydrates = 5.5M,
                    Protein = 0.6M,
                    Fats = 0.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Green peas",
                    CaloriesValue = 73,
                    Carbohydrates = 13.3M,
                    Protein = 5.0M,
                    Fats = 0.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "White cabbage",
                    CaloriesValue = 29,
                    Carbohydrates = 5.4M,
                    Protein = 1.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Red cabbage",
                    CaloriesValue = 32,
                    Carbohydrates = 6.1M,
                    Protein = 1.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Cauliflower",
                    CaloriesValue = 29,
                    Carbohydrates = 19.7M,
                    Protein = 2.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Zucchini",
                    CaloriesValue = 28,
                    Carbohydrates = 5.7M,
                    Protein = 0.6M,
                    Fats = 0.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Potato",
                    CaloriesValue = 84,
                    Carbohydrates = 19.7M,
                    Protein = 2,
                    Fats = 0.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Leek",
                    CaloriesValue = 42,
                    Carbohydrates = 7.3M,
                    Protein = 3,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Cucumber",
                    CaloriesValue = 14,
                    Carbohydrates = 9.5M,
                    Protein = 30.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Leek",
                    CaloriesValue = 42,
                    Carbohydrates = 7.3M,
                    Protein = 3,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Carrot",
                    CaloriesValue = 32,
                    Carbohydrates = 7M,
                    Protein = 1.3M,
                    Fats = 0.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Radish",
                    CaloriesValue = 22,
                    Carbohydrates = 4.1M,
                    Protein = 1.2M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Beetroot",
                    CaloriesValue = 49,
                    Carbohydrates = 10.8M,
                    Protein = 1.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Tomato",
                    CaloriesValue = 19,
                    Carbohydrates = 4.2M,
                    Protein = 0.6M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Green beans",
                    CaloriesValue = 33,
                    Carbohydrates = 4.3M,
                    Protein = 4,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Garlic",
                    CaloriesValue = 108,
                    Carbohydrates = 21.2M,
                    Protein = 6.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Spinach",
                    CaloriesValue = 22,
                    Carbohydrates = 2.3M,
                    Protein = 2.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Sorrel",
                    CaloriesValue = 29,
                    Carbohydrates = 5.3M,
                    Protein = 1.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Bulb onions",
                    CaloriesValue = 44,
                    Carbohydrates = 9.5M,
                    Protein = 1.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Pease",
                    CaloriesValue = 323,
                    Carbohydrates = 57.5M,
                    Protein = 23,
                    Fats = 1.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Lentils",
                    CaloriesValue = 313,
                    Carbohydrates = 53.7M,
                    Protein = 24.8M,
                    Fats = 1.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                new Product
                {
                    Name = "Haricot bean",
                    CaloriesValue = 308,
                    Carbohydrates = 54.5M,
                    Protein = 022.3M,
                    Fats = 1.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryVeg
                },
                #endregion

                #region init Breads & Cereals

                new Product
                {
                    Name = "Rye bread",
                    CaloriesValue = 214,
                    Carbohydrates = 49.8M,
                    Protein = 4.7M,
                    Fats = 0.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Wheat bread",
                    CaloriesValue = 252,
                    Carbohydrates = 53.4M,
                    Protein = 7.7M,
                    Fats = 2.4M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Rye flour",
                    CaloriesValue = 327,
                    Carbohydrates = 76.95M,
                    Protein = 6.9M,
                    Fats = 1.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Wheat flour",
                    CaloriesValue = 328,
                    Carbohydrates = 74.2M,
                    Protein = 0.8M,
                    Fats = 10.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Semolina",
                    CaloriesValue = 327,
                    Carbohydrates = 73.5M,
                    Protein = 11.6M,
                    Fats = 0.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Oat groats",
                    CaloriesValue = 345,
                    Carbohydrates = 65.5M,
                    Protein = 11.9M,
                    Fats = 5.8M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Pearl barley",
                    CaloriesValue = 325,
                    Carbohydrates = 73.5M,
                    Protein = 9.3M,
                    Fats = 1.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Barley grits",
                    CaloriesValue = 325,
                    Carbohydrates = 71.7M,
                    Protein = 10.4M,
                    Fats = 1.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Rice",
                    CaloriesValue = 325,
                    Carbohydrates = 73.7M,
                    Protein = 7,
                    Fats = 0.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Millet",
                    CaloriesValue = 334,
                    Carbohydrates = 69.3M,
                    Protein = 12,
                    Fats = 2.9M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                new Product
                {
                    Name = "Corn grits",
                    CaloriesValue = 328,
                    Carbohydrates = 76,
                    Protein = 8.3M,
                    Fats = 1.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryBreads
                },
                #endregion

                #region init Meat

                new Product
                {
                    Name = "Mutton",
                    CaloriesValue = 201,
                    Carbohydrates = 0,
                    Protein = 16.2M,
                    Fats = 15.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Beef",
                    CaloriesValue = 191,
                    Carbohydrates = 0,
                    Protein = 18.7M,
                    Fats = 12.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Beef Brains",
                    CaloriesValue = 126,
                    Carbohydrates = 0,
                    Protein = 9.3M,
                    Fats = 9.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Beef Tongue",
                    CaloriesValue = 160,
                    Carbohydrates = 0,
                    Protein = 13.4M,
                    Fats = 12.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Horsemeat",
                    CaloriesValue = 149,
                    Carbohydrates = 0,
                    Protein = 20.3M,
                    Fats = 7.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Rabbit meat",
                    CaloriesValue = 197,
                    Carbohydrates = 0,
                    Protein = 20.6M,
                    Fats = 12.8M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Lean pork",
                    CaloriesValue = 318,
                    Carbohydrates = 0,
                    Protein = 16.3M,
                    Fats = 27.9M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Fatty pork",
                    CaloriesValue = 484,
                    Carbohydrates = 0,
                    Protein = 11.6M,
                    Fats = 49.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Pork kidney",
                    CaloriesValue = 84,
                    Carbohydrates = 0,
                    Protein = 13.2M,
                    Fats = 3.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Pork liver",
                    CaloriesValue = 105,
                    Carbohydrates = 0,
                    Protein = 18.6M,
                    Fats = 3.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Pork heart",
                    CaloriesValue = 87,
                    Carbohydrates = 0,
                    Protein = 15.2M,
                    Fats = 3.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Pig tongue",
                    CaloriesValue = 203,
                    Carbohydrates = 0,
                    Protein = 14.4M,
                    Fats = 16.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Veal",
                    CaloriesValue = 91,
                    Carbohydrates = 0,
                    Protein = 19.9M,
                    Fats = 1.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Goose",
                    CaloriesValue = 359,
                    Carbohydrates = 0,
                    Protein = 16.6M,
                    Fats = 33.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Turkey meat",
                    CaloriesValue = 192,
                    Carbohydrates = 0.6M,
                    Protein = 21.1M,
                    Fats = 12.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Chicken",
                    CaloriesValue = 161,
                    Carbohydrates = 0.8M,
                    Protein = 20.4M,
                    Fats = 8.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },
                new Product
                {
                    Name = "Duck",
                    CaloriesValue = 348,
                    Carbohydrates = 0,
                    Protein = 16.4M,
                    Fats = 61.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryMeat
                },

                #endregion

                #region init Fish & Seafood

                new Product
                {
                    Name = "Pink salmon",
                    CaloriesValue = 151,
                    Carbohydrates = 0,
                    Protein = 21.2M,
                    Fats = 17.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Squid",
                    CaloriesValue = 77,
                    Carbohydrates = 0,
                    Protein = 18.2M,
                    Fats = 0.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Flounder",
                    CaloriesValue = 86,
                    Carbohydrates = 0,
                    Protein = 16,
                    Fats = 12.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Crucian",
                    CaloriesValue = 84,
                    Carbohydrates = 0,
                    Protein = 17.5M,
                    Fats = 1.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Carp",
                    CaloriesValue = 95,
                    Carbohydrates = 0,
                    Protein = 16,
                    Fats = 13.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Sprat",
                    CaloriesValue = 142,
                    Carbohydrates = 0,
                    Protein = 14.2M,
                    Fats = 9.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Shrimp",
                    CaloriesValue = 85,
                    Carbohydrates = 0,
                    Protein = 18,
                    Fats = 0.9M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Bream",
                    CaloriesValue = 109,
                    Carbohydrates = 0,
                    Protein = 17.2M,
                    Fats = 4.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Salmon",
                    CaloriesValue = 200,
                    Carbohydrates = 0,
                    Protein = 19.2M,
                    Fats = 13.8M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Boiled mussels",
                    CaloriesValue = 53,
                    Carbohydrates = 0,
                    Protein = 9.7M,
                    Fats = 1.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Capelin",
                    CaloriesValue = 159,
                    Carbohydrates = 0,
                    Protein = 13.1M,
                    Fats = 11.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Sea perch",
                    CaloriesValue = 123,
                    Carbohydrates = 0,
                    Protein = 17.2M,
                    Fats = 5.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "River perch",
                    CaloriesValue = 80,
                    Carbohydrates = 0,
                    Protein = 18.3M,
                    Fats = 0.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Sturgeon",
                    CaloriesValue = 161,
                    Carbohydrates = 0,
                    Protein = 16.5M,
                    Fats = 10.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Octopus",
                    CaloriesValue = 74,
                    Carbohydrates = 0,
                    Protein = 18.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Halibut",
                    CaloriesValue = 106,
                    Carbohydrates = 0,
                    Protein = 18.5M,
                    Fats = 3.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Roach",
                    CaloriesValue = 108,
                    Carbohydrates = 0,
                    Protein = 18.5M,
                    Fats = 0.4M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Boiled crayfish",
                    CaloriesValue = 96,
                    Carbohydrates = 1.1M,
                    Protein = 20.3M,
                    Fats = 1.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Herring",
                    CaloriesValue = 248,
                    Carbohydrates = 0,
                    Protein = 19.9M,
                    Fats = 17.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Scomber",
                    CaloriesValue = 158,
                    Carbohydrates = 0,
                    Protein = 18,
                    Fats = 9.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Catfish",
                    CaloriesValue = 141,
                    Carbohydrates = 0,
                    Protein = 16.7M,
                    Fats = 8.4M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Pikeperch",
                    CaloriesValue = 81,
                    Carbohydrates = 0,
                    Protein = 19,
                    Fats = 0.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Cod",
                    CaloriesValue = 76,
                    Carbohydrates = 0,
                    Protein = 17.7M,
                    Fats = 0.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Tuna",
                    CaloriesValue = 95,
                    Carbohydrates = 0,
                    Protein = 21.7M,
                    Fats = 1.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Sea eel",
                    CaloriesValue = 331,
                    Carbohydrates = 0,
                    Protein = 14.2M,
                    Fats = 30.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Oysters",
                    CaloriesValue = 91,
                    Carbohydrates = 6.2M,
                    Protein = 14.4M,
                    Fats = 0.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Trout",
                    CaloriesValue = 99,
                    Carbohydrates = 0,
                    Protein = 19.6M,
                    Fats = 2.1M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Hake",
                    CaloriesValue = 84,
                    Carbohydrates = 0,
                    Protein = 16.4M,
                    Fats = 2.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },
                new Product
                {
                    Name = "Pike",
                    CaloriesValue = 83,
                    Carbohydrates = 0,
                    Protein = 18.2M,
                    Fats = 0.8M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFish
                },

                #endregion

                #region init Fruits & berries

                new Product
                {
                    Name = "Apricot",
                    CaloriesValue = 44,
                    Carbohydrates = 10.1M,
                    Protein = 0.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Pineapple",
                    CaloriesValue = 49,
                    Carbohydrates = 11.9M,
                    Protein = 0.3M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Orange",
                    CaloriesValue = 38,
                    Carbohydrates = 8.6M,
                    Protein = 0.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Banana",
                    CaloriesValue = 87,
                    Carbohydrates = 22.1M,
                    Protein = 1.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Lingonberry",
                    CaloriesValue = 42,
                    Carbohydrates = 8.8M,
                    Protein = 0.6M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Grape",
                    CaloriesValue = 73,
                    Carbohydrates = 17.8M,
                    Protein = 0.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Cherry",
                    CaloriesValue = 46,
                    Carbohydrates = 11.1M,
                    Protein = 0.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Garnet",
                    CaloriesValue = 53,
                    Carbohydrates = 11.9M,
                    Protein = 0.79M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Grapefruit",
                    CaloriesValue = 37,
                    Carbohydrates = 7.5M,
                    Protein = 0.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Pear",
                    CaloriesValue = 41,
                    Carbohydrates = 10.6M,
                    Protein = 0.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Blueberry",
                    CaloriesValue = 35,
                    Carbohydrates = 7.4M,
                    Protein = 1.1M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Melon",
                    CaloriesValue = 34,
                    Carbohydrates = 7.3M,
                    Protein = 0.8M,
                    Fats = 0.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Blackberry",
                    CaloriesValue = 31,
                    Carbohydrates = 5.1M,
                    Protein = 1.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Figs",
                    CaloriesValue = 57,
                    Carbohydrates = 13.7M,
                    Protein = 0.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Kiwi",
                    CaloriesValue = 46,
                    Carbohydrates = 9.7M,
                    Protein = 1,
                    Fats = 0.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Figs",
                    CaloriesValue = 57,
                    Carbohydrates = 13.7M,
                    Protein = 0.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Dogwood",
                    CaloriesValue = 42,
                    Carbohydrates = 9.4M,
                    Protein = 1.1M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Strawberry",
                    CaloriesValue = 30,
                    Carbohydrates = 7,
                    Protein = 0.6M,
                    Fats = 0.4M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Cranberry",
                    CaloriesValue = 27,
                    Carbohydrates = 4.9M,
                    Protein = 0.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Gooseberry",
                    CaloriesValue = 43,
                    Carbohydrates = 9.7M,
                    Protein = 0.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Lemon",
                    CaloriesValue = 30,
                    Carbohydrates = 3.3M,
                    Protein = 0.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Raspberries",
                    CaloriesValue = 43,
                    Carbohydrates = 9.2M,
                    Protein = 0.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Mandarin",
                    CaloriesValue = 39,
                    Carbohydrates = 8.8M,
                    Protein = 0.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Mango",
                    CaloriesValue = 69,
                    Carbohydrates = 11.8M,
                    Protein = 0.6M,
                    Fats = 0.4M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Sea buckthorn",
                    CaloriesValue = 31,
                    Carbohydrates = 5.6M,
                    Protein = 0.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Peach",
                    CaloriesValue = 42,
                    Carbohydrates = 10.1M,
                    Protein = 0.9M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Plum",
                    CaloriesValue = 41,
                    Carbohydrates = 9.7M,
                    Protein = 0.8M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Persimmon",
                    CaloriesValue = 61,
                    Carbohydrates = 15.7M,
                    Protein = 0.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Sweet cherry",
                    CaloriesValue = 54,
                    Carbohydrates = 12.5M,
                    Protein = 1.3M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Apple",
                    CaloriesValue = 48,
                    Carbohydrates = 11.4M,
                    Protein = 0.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Currant",
                    CaloriesValue = 38,
                    Carbohydrates = 8,
                    Protein = 0.6M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },
                new Product
                {
                    Name = "Rowan",
                    CaloriesValue = 57,
                    Carbohydrates = 12.2M,
                    Protein = 1.6M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryFruits
                },

                #endregion

                #region init Nuts, Dried Fruits

                new Product
                {
                    Name = "Peanut",
                    CaloriesValue = 555,
                    Carbohydrates = 9.9M,
                    Protein = 26.2M,
                    Fats = 45.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Walnut",
                    CaloriesValue = 662,
                    Carbohydrates = 10.6M,
                    Protein = 013.5M,
                    Fats = 61.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Raisins",
                    CaloriesValue = 280,
                    Carbohydrates = 71,
                    Protein = 2.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Cashew",
                    CaloriesValue = 647,
                    Carbohydrates = 13.3M,
                    Protein = 25.8M,
                    Fats = 54.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Dried apricots",
                    CaloriesValue = 270,
                    Carbohydrates = 65.3M,
                    Protein = 5.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Almond",
                    CaloriesValue = 643,
                    Carbohydrates = 13.4M,
                    Protein = 18.3M,
                    Fats = 57.9M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Sunflower seed",
                    CaloriesValue = 582,
                    Carbohydrates = 5.3M,
                    Protein = 20.9M,
                    Fats = 52.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Date fruit",
                    CaloriesValue = 277,
                    Carbohydrates = 69.6M,
                    Protein = 2.5M,
                    Fats = 0.4M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Pistachios",
                    CaloriesValue = 4555,
                    Carbohydrates = 7.3M,
                    Protein = 0.7M,
                    Fats = 50.5M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Hazelnut",
                    CaloriesValue = 701,
                    Carbohydrates = 19.8M,
                    Protein = 16.3M,
                    Fats = 66.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Prunes",
                    CaloriesValue = 262,
                    Carbohydrates = 165.3M,
                    Protein = 0.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },
                new Product
                {
                    Name = "Dried apples",
                    CaloriesValue = 275,
                    Carbohydrates = 68.3M,
                    Protein = 3.1M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryNuts
                },

                #endregion

                #region init Confectionery

                new Product
                {
                    Name = "Jam",
                    CaloriesValue = 286,
                    Carbohydrates = 74.5M,
                    Protein = 0.4M,
                    Fats = 0.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Waffles",
                    CaloriesValue = 425,
                    Carbohydrates = 53.1M,
                    Protein = 8.2M,
                    Fats = 19.8M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Hematogen",
                    CaloriesValue = 352,
                    Carbohydrates = 75.5M,
                    Protein = 6.2M,
                    Fats = 02.8M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Marshmallows",
                    CaloriesValue = 295,
                    Carbohydrates = 77.3M,
                    Protein = 0.7M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Iris",
                    CaloriesValue = 384,
                    Carbohydrates = 781.2M,
                    Protein = 3.1M,
                    Fats = 7.7M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Caramel",
                    CaloriesValue = 291,
                    Carbohydrates = 77.35M,
                    Protein = 0,
                    Fats = 0.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Marmalade",
                    CaloriesValue = 289,
                    Carbohydrates = 77.3M,
                    Protein = 0,
                    Fats = 0.2M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Honey",
                    CaloriesValue = 312,
                    Carbohydrates = 80.5M,
                    Protein = 0.6M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Ice cream",
                    CaloriesValue = 223,
                    Carbohydrates = 20.5M,
                    Protein = 3.6M,
                    Fats = 15.52M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Oatmeal cookies",
                    CaloriesValue = 430,
                    Carbohydrates = 71.45M,
                    Protein = 6.5M,
                    Fats = 14.12M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Gingerbread",
                    CaloriesValue = 333,
                    Carbohydrates = 77.1M,
                    Protein = 4.4M,
                    Fats = 2.9M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Sugar",
                    CaloriesValue = 377,
                    Carbohydrates = 99.6M,
                    Protein = 0.2M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Halva",
                    CaloriesValue = 519,
                    Carbohydrates = 54.6M,
                    Protein = 11.4M,
                    Fats = 29.3M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Dark chocolate",
                    CaloriesValue = 546,
                    Carbohydrates = 52.4M,
                    Protein = 5.2M,
                    Fats = 35.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },
                new Product
                {
                    Name = "Milk chocolate",
                    CaloriesValue = 552,
                    Carbohydrates = 52.4M,
                    Protein = 6.7M,
                    Fats = 35.6M,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryConf
                },

                #endregion

                #region init Alcohol

                new Product
                {
                    Name = "Brandy",
                    CaloriesValue = 225,
                    Carbohydrates = 1,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Vermouth",
                    CaloriesValue = 155,
                    Carbohydrates = 15.9M,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Dry wine",
                    CaloriesValue = 66,
                    Carbohydrates = 0,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Semi-dry wine",
                    CaloriesValue = 78,
                    Carbohydrates = 2.5M,
                    Protein = 0.3M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Dessert wine",
                    CaloriesValue = 225,
                    Carbohydrates = 20,
                    Protein = 0.5M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Semisweet Wine",
                    CaloriesValue = 88,
                    Carbohydrates = 5,
                    Protein = 0.2M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Whiskey",
                    CaloriesValue = 222,
                    Carbohydrates = 10,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Vodka",
                    CaloriesValue = 234,
                    Carbohydrates = 0.1M,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Gin",
                    CaloriesValue = 223,
                    Carbohydrates = 0,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Cognac",
                    CaloriesValue = 223,
                    Carbohydrates = 0.1M,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Liquor",
                    CaloriesValue = 344,
                    Carbohydrates = 53,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Port wine",
                    CaloriesValue = 167,
                    Carbohydrates = 13.8M,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Rum",
                    CaloriesValue = 217,
                    Carbohydrates = 0,
                    Protein = 0,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                },
                new Product
                {
                    Name = "Champagne",
                    CaloriesValue = 223,
                    Carbohydrates = 5.2M,
                    Protein = 0.3M,
                    Fats = 0,
                    PhotoUrl = "PHOTO_URL",
                    Category = categoryAlc
                }

                #endregion
            };
            await context.Set<Product>().AddRangeAsync(products);
        }
    }
}