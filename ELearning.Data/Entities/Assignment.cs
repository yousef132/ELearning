namespace ELearning.Data.Entities
{
    public class Assignment : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }
        public TimedEntity TimedEntity { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; } 
    }
}