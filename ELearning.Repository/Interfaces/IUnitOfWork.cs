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

		Task<int> CompleteAsync();
    }
}
