using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class RefreshToken : IBaseEntity
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }

        /* Navigation Properties */

        public int UserId { get; set; }
        public User User { get; set; }
    }
}