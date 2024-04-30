using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class CourseViewModel
    {

        public string Name { get; set; }
        [Range(1,100)]
        public int Duration { get; set; }

        public double Price { get; set; }

        public string Language { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }

        public string SkillLevel { get; set; }
    }
}
