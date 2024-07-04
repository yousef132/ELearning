namespace E_Learning.Models
{
    public class CourseViewModel
    {

        public string Name { get; set; }
        public double Price { get; set; }
        public string? ImagePath { get; set; }
        public string Language { get; set; }

        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? UserId { get; set; }
        public int? Id { get; set; }

        public string SkillLevel { get; set; }
    }
}
