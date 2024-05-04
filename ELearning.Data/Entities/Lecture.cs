namespace ELearning.Data.Entities
{
    public class Lecture:BaseEntity
    {
        public string Name { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; }


        public ICollection<Assignment> Assignments { get; set; }
        // instructor attachments like (image , file , video)
        public ICollection<Attachment> Attachments { get; set; }
		public ICollection<Exam> Exams { get; set; }



	}
}
