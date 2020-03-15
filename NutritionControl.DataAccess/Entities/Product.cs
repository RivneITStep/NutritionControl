using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class Product : IBaseEntity
    {
        public Product()
        {
            Receipts = new HashSet<ProductReceipt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal CaloriesValue { get; set; }
        public decimal Protein { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbohydrates { get; set; }

        /* Navigation Properties */

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductReceipt> Receipts { get; set; }
        public ICollection<FoodIntake> FoodIntakes { get; set; }
    }
}