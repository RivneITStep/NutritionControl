namespace NutritionControl.DTO.Models
{
    public class ProfileDto
    { 
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? Age { get; set; }
        public decimal? BMI { get; set; }
        public decimal? GoalWeight { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}