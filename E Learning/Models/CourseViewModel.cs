using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class CourseViewModel
    {

        public string Name { get; set; }
        public double Price { get; set; }

        public string Language { get; set; }
		[StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]

		public string Description { get; set; }
        public IFormFile? Image { get; set; }

        public string SkillLevel { get; set; }
    }
}
