using ELearning.Data.Entities;

namespace Store.Repository.Interfaces
{
    public interface IExamRepository
    {
        ICollection<Exam> GetExamsByLectureId(int lectureId);
    }
}
