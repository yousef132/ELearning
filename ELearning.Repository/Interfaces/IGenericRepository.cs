
using ELearning.BLL.Specifications;
using ELearning.Data.Entities;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int Id);
        Task<IReadOnlyList<TEntity>> GetAllAsync(); 
        Task<TEntity> GetWithSpecificationsByIdAsync(ISpecification<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetWithSpecificationsAllAsync(ISpecification<TEntity> specs); 

       // Task<int> CountSpecificationAsync(ISpecification<TEntity> specs);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);


    }
}
