using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Configuration.TypeInitializers;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration
{
    public class EntityInitializer : IEntityInitializer
    {
        private readonly List<ITypeInitializer> typeInitializers;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly DbContext context;

        public EntityInitializer(UserManager<User> _userManager,
                                 RoleManager<IdentityRole<int>> _roleManager,
                                 DbContext _context)
        {
            typeInitializers = new List<ITypeInitializer>();
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;

            //add concrete initializers
            //order is IMPORTANT (for example, you first need to add categories and only then products that are category-dependent)
            this.AddConfig(new CategoriesInitializer());
            this.AddConfig(new ProductsInitializer());
        }

        public void AddConfig(ITypeInitializer typeInitializer)
        {
            typeInitializers.Add(typeInitializer);
        }

        public async Task SeedData()
        {
            //always delete and recreate database with seeded data
            bool deleted = await context.Database.EnsureDeletedAsync();
            bool created = await context.Database.EnsureCreatedAsync();

            //create test users and admins
            await InitializeIdetity();

            //go through all the initializers and seed them all
            foreach (var initializer in typeInitializers)
            {
                await initializer.Init(context);
                await context.SaveChangesAsync();
            }
        }

        private async Task InitializeIdetity()
        {
            //Create roles
            await roleManager.CreateAsync(new IdentityRole<int> { Name = "admin" });

            //Create users
            await userManager.CreateAsync(new User
            {
                UserName = "vasyan@gmail.com",
                Email = "vasyan@gmail.com"
            }, "Qwe123!!");

            await userManager.CreateAsync(new User
            {
                UserName = "semen@gmail.com",
                Email = "semen@gmail.com"
            }, "Qwe123!!");

            await userManager.CreateAsync(new User
            {
                UserName = "kolyan@gmail.com",
                Email = "kolyan@gmail.com",
            }, "Qwe123!!");

            await userManager.CreateAsync(new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            }, "Qwe123!!");

            var admin = await userManager.FindByEmailAsync("admin@gmail.com");
            await userManager.AddToRoleAsync(admin, "admin");
        }
    }
}
