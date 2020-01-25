using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NutritionControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _db;

        public ValuesController(Microsoft.EntityFrameworkCore.DbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public object GetTestProducts()
        {
            //TEST VERSION
            //ITS WRONG
            var data = _db.Set<DataAccess.Entities.Product>().Include(x=>x.Category).ToList();
            return data;
            //    .Include(x => x.Category).Select(x => new
            //{
            //    x.Name,
            //    x.CaloriesValue,
            //    x.Fats,
            //    x.Protein,
            //    x.PhotoUrl,
            //    Category = x.Category.Name
            //}).ToList();
        }

    }
}