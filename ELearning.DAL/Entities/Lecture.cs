namespace ELearning.Data.Entities
{
    public class Lecture:BaseEntity
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }


    }
}
