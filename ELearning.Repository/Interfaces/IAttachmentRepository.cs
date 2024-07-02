using ELearning.Data.Entities;

namespace Store.Repository.Interfaces
{
    public interface IAttachmentRepository
    {
        ICollection<Attachment> GetAttachmentsByLectureId(int lectureId);
    }

}
