using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class FoodIntake : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime DateOfIntake { get; set; }
        public string Type { get; set; }
        public decimal FoodWeight { get; set; }

        /* Navigation Properties */

		public int UserId { get; set; }
        public User User { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
    }
}