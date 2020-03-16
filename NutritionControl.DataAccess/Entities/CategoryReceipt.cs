using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class CategoryReceipt: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* Navigation Properties */

        public ICollection<Receipt> Receipts { get; set; }
    }
}