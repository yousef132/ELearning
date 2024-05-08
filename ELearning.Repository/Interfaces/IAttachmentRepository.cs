using ELearning.Data.Entities;

namespace Store.Repository.Interfaces
{
    public interface IAttachmentRepository
    {
        ICollection<Attachment> GetAttachmentsByLectureId(int lectureId);
    }
    public interface IExamRepository
    {
        ICollection<Exam> GetExamsByCourseId(int courseId);
    }
    public interface IAssignmentRepository
    {
        ICollection<Assignment> GetAssignmentsByCourseId(int courseId);
    }
}
