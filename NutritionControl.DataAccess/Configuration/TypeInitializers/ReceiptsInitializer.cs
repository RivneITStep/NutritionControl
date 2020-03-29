using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
    public class ReceiptsInitializer : ITypeInitializer
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

            Receipt r = new Receipt
            {
                Description = "This dish has less than 400 calories per serve & you can make it in 30 minutes from scratch, which makes it a great after work dinner for the family or dinner party.",
                Name = "Spanish Fish Stew",
                Method = @"In a non stick frypan heat olive oil and cook chorizo a couple of minutes on each side. Take off onto a plate and set aside. Now add onion and capsicum and stir-fry until softened. Add white wine and reduce liquid down to half then add tomatoes, garlic, paprika, beans, sugar, and beans. Turn down to a simmer and simmer for 10 minutes…if it needs more paprika or herbs you can add more.
After 10 minutes add cherry tomatoes,
                peas and parsley,
                then place fish on top of stew then place lid on top.Depending on the thickness of the fish cook about 10 minutes,
                turn half way.
Serve immediately.",
                Category = categoryFish,
                PhotoUrl = "https:////img.taste.com.au/Sv5jfW9p/taste/2016/11/spanish-style-fish-stew-106988-1.jpeg",
                Products = new List<ProductReceipt>()
            };
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Cod"),
                Count = 4,
                Measurment = "g"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Tomato"),
                Count = 8,
                Measurment = "g"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Bulb onions"),
                Count = 0.3,
                Measurment = "g"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Green peas"),
                Count = 0.4,
                Measurment = "g"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Semi-dry wine"),
                Count = 0.5,
                Measurment = "ml"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Carrot"),
                Count = 0.2,
                Measurment = "g"
            });
            r.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Potato"),
                Count = 1.5,
                Measurment = "ml"
            });
            await context.Set<Receipt>().AddAsync(r);

            Receipt r1 = new Receipt
            {
                Description = "This simple yet delicious 360 calories soup is very easy to make. Loaded up with vegetables makes this nutritious and the pasta and ham will fill you up.",
                Name = "Vegetable Ham & Pasta Soup",
                Category = categorySoups,
                PhotoUrl = "https:////img.taste.com.au/TE-bFa9H/taste/2016/11/ham-white-bean-and-pasta-soup-80389-1.jpeg",
                Method= @"We used a slow cooker for this recipe. Cut all the fat off the ham hock, as much as you can. Place into your slow cooker with onion and stock. Cook for 4 hours.
After 4 hours take out the ham and slice the meat off the bone and place back into slow cooker.Add all the other ingredients except pasta.Cook a further 2 - 4 hours,
                depending on your slow cooker.You can add some extra water if you need to, if you like a more soupy soup.Season with salt and pepper to suit your taste.
When you are happy with the soup add the pasta in, this should only take about 15 - 20 minutes to cook.",
                Products = new List<ProductReceipt>()
            };
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Beef"),
                Count = 1,
                Measurment = "g"
            });
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Zucchini"),
                Count = 0.2,
                Measurment = "g"
            });
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Carrot"),
                Count = 0.2,
                Measurment = "g"
            });
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Potato"),
                Count = 1,
                Measurment = "g"
            });
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Bulb onions"),
                Count = 0.3,
                Measurment = "g"
            });
            r1.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Garlic"),
                Count = 0.6,
                Measurment = "g"
            });

            await context.Set<Receipt>().AddAsync(r1);

            Receipt r2 = new Receipt
            {
                Description = "Brown rice is considered a 'whole grain' and has a low GI rating. Nutrient benefits include antioxidents, high in fiber, high in manganese - all packed into this soup.",
                Name = "Chicken & Brown Rice Soup",
                Category = categorySoups,
                PhotoUrl = "https:////tiger-corporation-us.com/wp-content/uploads/2019/07/chicken-brown-rice-soup-900x600.jpg",
                Method= @"Shred the breast meat off the chicken and set aside.
In a med sized pot, sauté onion in olive oil for 5 mins, then add the chilli.  Add the diced celery, carrot and cook a further 5 minutes stirring.
Now add the zucchini, garlic, and bay leaf, oregano, paprika, chicken stock and water.  Then add the dried brown rice, stirring so it doesn’t stick to the bottom of pan.  Simmer for 10 mins stirring occasionally.
Check to see if the rice is cooked, if not continue to simmer.  If it is cooked then add the corn kernels and chicken and simmer for a couple of minutes until they have heated through. Season with S&P.
Serve immediately.",
                Products = new List<ProductReceipt>()
            };
            r2.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "chicken"),
                Count = 1,
                Measurment = "g"
            });
            r2.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Zucchini"),
                Count = 0.2,
                Measurment = "g"
            });
            r2.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Carrot"),
                Count = 0.2,
                Measurment = "g"
            });
            r2.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Potato"),
                Count = 1,
                Measurment = "g"
            });
            r2.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Bulb onions"),
                Count = 0.3,
                Measurment = "g"
            });
            r2.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Rice"),
                Count = 1,
                Measurment = "g"
            });

            await context.Set<Receipt>().AddAsync(r2);

            Receipt r3 = new Receipt
            {
                Description = "This is a typical french dish which is also known as Beef bourguignon. Our recipe is a one pot dish which can be cooked in a pot on the stove or in a slow cooker.",
                Name = "Beef Burgundy",
                Category = categoryMeat,
                PhotoUrl = "https:////hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190828-beef-bourguignon-0155-landscape-pf-1568132096.jpg?crop=1.00xw:0.753xh;0,0.144xh&resize=1200:*",
                Method = @"Heat 1 tbsp. olive oil in pan and sauté onions for 10 minutes on low med heat, you want your onions not to burn or colour. Once cooked take out of pan, place in slow cooker.
Now add 1 tsp. olive oil and fry bacon until cooked. Again take out of pan, add to slow cooker.
Add remaining olive oil and brown your beef, this should take 5 minutes, stirring, add to slow cooker.
Add remaining ingredients - garlic, tomato paste, wine, bay leaves, thyme, heated beef stock, and season with S & P to taste.
Mix everything in your cooker around and add the potatoes, carrots and set for 4 hours on high or 8 hours on low. If cooking in oven set to 140C making sure your casserole dish has a lid on.
1-2 hours before ready, add your frozen peas and add cornflour mixed with water and stir.
This is a one pot dish, so no need to serve with anything, except you can steam some additional vegetables like broccoli and cauliflower.",
                Products = new List<ProductReceipt>()
            };
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Beef"),
                Count = 1,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Tomato"),
                Count = 0.3,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Carrot"),
                Count = 0.2,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Potato"),
                Count = 1,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Bulb onions"),
                Count = 0.3,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Garlic"),
                Count = 0.6,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Semi-dry wine"),
                Count = 0.6,
                Measurment = "g"
            });
            r3.Products.Add(new ProductReceipt
            {
                Product = await context.Set<Product>().FirstOrDefaultAsync(x => x.Name == "Green peas"),
                Count = 0.3,
                Measurment = "g"
            });

            await context.Set<Receipt>().AddAsync(r3);
        }
    }
}
