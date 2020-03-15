using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;

namespace NutritionControl.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        #region DbSets

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ProductReceipt> ProductReceipts { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
        public DbSet<WeightInfo> WeightInfos { get; set; }
        public DbSet<WaterValue> WaterValues { get; set; }
        public DbSet<FoodIntake> FoodIntakes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
		//public DbSet<FoodIntakeProduct> FoodIntakeProducts { get; set; }

        #endregion

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			/* Product -> Receipts */
			
            modelBuilder.Entity<ProductReceipt>()
               .HasKey(t => new { t.ProductId, t.ReceiptId });

            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.Receipts)
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Receipt)
                .WithMany(p => p.Products)
                .HasForeignKey(pr => pr.ReceiptId);

			/* User -> UserAdditional Info */

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserAdditionalInfo)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserAdditionalInfo>(ui => ui.UserId);

            /* User -> RefreshToken */

			modelBuilder.Entity<User>()
               .HasOne(u => u.RefreshToken)
               .WithOne(rt => rt.User)
               .HasForeignKey<RefreshToken>(rt => rt.UserId);



			//modelBuilder.Entity<FoodIntakeProduct>()
			//	.HasKey(t => new { t.ProductId, t.FoodIntakeId });

			//modelBuilder.Entity<FoodIntakeProduct>()
			//	.HasOne(fir => fir.FoodIntake)
			//	.WithMany(p => p.Products)
			//	.HasForeignKey(pr => pr.FoodIntakeId);

			//modelBuilder.Entity<FoodIntakeProduct>()
			//	.HasOne(fir => fir.Product)
			//	.WithMany(p => p.FoodIntakes)
			//	.HasForeignKey(pr => pr.ProductId);


			base.OnModelCreating(modelBuilder);
        }
    }
}