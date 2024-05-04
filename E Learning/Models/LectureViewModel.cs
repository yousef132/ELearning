using ELearning.Data.Entities;

namespace E_Learning.Models
{
	public class LectureViewModel
	{
		public string LectureName { get; set; }
		public IFormFile File { get; set; }
		public int CourseId { get; set; }
		public AttachmentType FileType { get; set; }
		public string Name { get; set; }
	
	}
}
