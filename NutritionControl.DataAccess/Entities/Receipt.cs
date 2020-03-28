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
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string PhotoUrl { get; set; }
        public string Method { get; set; }
        public CategoryReceipt Category { get; set; }

        /* Navigation Properties */

        public ICollection<ProductReceipt> Products { get; set; }
    }
}