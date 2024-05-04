using ELearning.Data.Entities.Question;

namespace ELearning.Data.Entities
{
    public class Exam : BaseEntity
    {

        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }
        public ICollection<StudentExam> StudentExams { get; set; }
        public ICollection<BaseQuestion> BaseQuestions { get; set; }
        public string Name { get; set; }

        public TimedEntity TimedEntity { get; set; }
    }
}
