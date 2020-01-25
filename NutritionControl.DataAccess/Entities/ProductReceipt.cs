using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class ProductReceipt : IBaseEntity
    {
        public int Id { get; set; }

        /* Navigation Properties */

        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}