using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class ProductLike : IBaseEntity
    {
        public int Id { get; set; }

        /* Navigation props */
        
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}