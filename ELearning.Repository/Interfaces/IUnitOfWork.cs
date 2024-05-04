using ELearning.BLL.Interfaces;
using ELearning.Data.Entities;
using Store.Repository.BasketRepository;

namespace Store.Repository.Interfaces
{
    public interface IUnitOfWork
    {

        IGenericRepository<TEntity> Reposirory<TEntity>() where TEntity : BaseEntity;
        ICacheRepository cacheRepository { get; set; }
		ICartRepository CartRepository { get; set; }

        //ILectureComponentsRepository<TEntity> LectureComponentsRepository where TEntity : BaseEntity; // Read-only
        // ILectureComponentsRepository<BaseEntity> LectureComponentsRepository { get; set; } // Read-only

        ILectureComponentsRepository<TEntity> LectureComponentsRepository<TEntity>() where TEntity : BaseEntity; 


        Task<int> CompleteAsync();


    }

}
