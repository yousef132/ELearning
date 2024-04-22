using ELearning.Data.Entities.Question;

namespace ELearning.Data.Entities
{
    public class Exam : BaseEntity
    {
        public ICollection<StudentExam> StudentExams { get; set; }
        public ICollection<BaseQuestion> BaseQuestions { get; set; }

        public TimedEntity TimedEntity { get; set; }
        // Course Has Many Exams
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
