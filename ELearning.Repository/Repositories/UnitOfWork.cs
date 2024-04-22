using ELearning.Data.Context;
using ELearning.Data.Entities;
using Store.Repository.Interfaces;
using System.Collections;

namespace Store.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ELearningDbContext context;
        private Hashtable repositories;

        public UnitOfWork(ELearningDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CompleteAsync() => await context.SaveChangesAsync();

        public IGenericRepository<TEntity> Reposirory<TEntity>() where TEntity : BaseEntity
        {

            if (repositories == null)
                repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name;
            if (!repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInsatnce = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);

                repositories.Add(entityKey, repositoryInsatnce);
            }
            return (IGenericRepository<TEntity>)repositories[entityKey];
        }
    }
}
