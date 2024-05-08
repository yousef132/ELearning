using ELearning.BLL.Interfaces;
using ELearning.Data.Entities;
using Store.Repository.BasketRepository;

namespace Store.Repository.Interfaces
{
    public interface IUnitOfWork
    {

        IGenericRepository<TEntity> Reposirory<TEntity>() where TEntity : BaseEntity;
		ICartRepository CartRepository { get; set; }

        //ILectureComponentsRepository<TEntity> LectureComponentsRepository where TEntity : BaseEntity; // Read-only
        // ILectureComponentsRepository<BaseEntity> LectureComponentsRepository { get; set; } // Read-only

        IAttachmentRepository AttachmentRepository { get; set; }
        IExamRepository ExamRepository { get; set; }
        IAssignmentRepository AssignmentRepository { get; set; }


        Task<int> CompleteAsync();


    }

}
