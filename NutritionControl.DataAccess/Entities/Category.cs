using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class Category : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* Navigation Properties */

        public ICollection<Product> Products { get; set; }
    }
}