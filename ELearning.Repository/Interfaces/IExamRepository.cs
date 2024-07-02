using ELearning.Data.Entities;
using ELearning.Data.Entities.Question;

namespace Store.Repository.Interfaces
{
    public interface IExamRepository
    {
        ICollection<Exam> GetExamsByCourseId(int courseId);

        ICollection<BaseQuestion> GetExamQuestions(int examId);

        ICollection<StudentExam> GetExamStudentsResult(int examId);

        public ICollection<StudentExam> GetGrades(string userId);

    }

}
