using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Configuration.TypeInitializers
{
	public class DiaryInitializer : ITypeInitializer
	{
		public async Task Init(DbContext context)
		{
			var user = await context.Set<User>().FirstOrDefaultAsync(x => x.Email == "vasyan@gmail.com");

			Random r = new Random();

			for(int i=0;i<60;i++)
			{
				await context.Set<WeightInfo>().AddAsync(new WeightInfo
				{
					DateOfMeasurement = DateTime.Now - TimeSpan.FromDays(60-i),
					User = user,
					WeightValue = 90 - (i / 6) - r.Next(0, 2)
				});
			}

			for (int i = 0; i < 60; i++)
			{
				await context.Set<WaterValue>().AddAsync(new WaterValue
				{
					DateOfMeasurement = DateTime.Now - TimeSpan.FromDays(60 - i),
					User = user,
					Value = r.Next(2500,3500)
				});
			}
		}
	}
}