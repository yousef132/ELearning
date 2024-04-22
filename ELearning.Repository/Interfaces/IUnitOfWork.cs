using ELearning.Data.Entities;

namespace Store.Repository.Interfaces
{
    public interface IUnitOfWork
    {

        IGenericRepository<TEntity> Reposirory<TEntity>() where TEntity : BaseEntity;

        Task<int> CompleteAsync();
    }
}
