using ELearning.Data.Entities;

namespace Store.Repository.Interfaces
{
    public interface ILectureComponentsRepository<T> where T : BaseEntity
    {
        ICollection<T> GetItemsByLectureId(int lectureId);
    }

}
