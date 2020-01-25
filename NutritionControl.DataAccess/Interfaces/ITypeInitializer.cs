using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Interfaces
{
    public interface ITypeInitializer
    {
        Task Init(DbContext context);
    }
}