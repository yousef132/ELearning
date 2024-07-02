using ELearning.Data.Context;
using ELearning.Data.Entities;
using Store.Repository.Interfaces;

namespace ELearning.BLL.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ELearningDbContext context;

        public AttachmentRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public ICollection<Attachment> GetAttachmentsByLectureId(int lectureId)
            => context.Attachments.Where(a => a.LectureId == lectureId).ToList();




    }


}
