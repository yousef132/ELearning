using ELearning.BLL.Specifications;
using ELearning.Data.Context;
using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Store.Repository.Interfaces;

namespace Store.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ELearningDbContext context;

        public GenericRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(TEntity entity)
         => await context.Set<TEntity>().AddAsync(entity);


        public async Task<TEntity> GetByIdAsync(int Id)
            => await context.Set<TEntity>().FindAsync(Id);
        public void Delete(TEntity entity)
            => context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await context.Set<TEntity>().ToListAsync();

        public void Update(TEntity entity)
            => context.Set<TEntity>().Update(entity);

        public async Task<TEntity> GetWithSpecificationsByIdAsync(ISpecification<TEntity> specs)
            => await ApplySpecs(specs).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<TEntity>> GetWithSpecificationsAllAsync(ISpecification<TEntity> specs)
        => await ApplySpecs(specs).ToListAsync();

        private IQueryable<TEntity> ApplySpecs(ISpecification<TEntity> specs)
            => SpecificationEvaluater<TEntity>.GetQuery(context.Set<TEntity>(), specs);

        //public async Task<int> CountSpecificationAsync(ISpecification<TEntity> specs)
        //    => await ApplySpecs(specs).CountAsync();    
    }
}
