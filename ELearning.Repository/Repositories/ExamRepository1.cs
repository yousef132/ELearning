using ELearning.Data.Context;
using ELearning.Data.Entities;
using ELearning.Data.Entities.Question;
using Microsoft.EntityFrameworkCore;
using Store.Repository.Interfaces;

namespace ELearning.BLL.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ELearningDbContext context;

        public ExamRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public ICollection<Exam> GetExamsByCourseId(int courseId)
            => context.Exams.Where(a => a.CourseId == courseId).ToList();

        public ICollection<BaseQuestion> GetExamQuestions(int examId)
        => context.BaseQuestions.Where(q => q.ExamId == examId).ToList();

        public ICollection<StudentExam> GetExamStudentsResult(int examId)
            => context.StudentExams
                       .Include(se => se.User)
                       .Where(se => se.ExamId == examId)
                       .OrderBy(se => se.Grade)
                       .ToList();
    }
}
