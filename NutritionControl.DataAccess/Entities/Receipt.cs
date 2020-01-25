using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class Receipt : IBaseEntity
    {
        public Receipt()
        {
            Products = new HashSet<ProductReceipt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CaloriesValue { get; set; }
        public string Description { get; set; }

        /* Navigation Properties */

        public ICollection<ProductReceipt> Products { get; set; }
    }
}