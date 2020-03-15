using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
	public class FoodIntakeProduct : IBaseEntity
	{
		public int Id { get; set; }

		/* Navigation props */

		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int FoodIntakeId { get; set; }
		public FoodIntake FoodIntake { get; set; }
	}
}