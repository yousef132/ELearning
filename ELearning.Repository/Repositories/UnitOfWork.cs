using ELearning.BLL.Interfaces;
using ELearning.Data.Context;
using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Store.Repository.BasketRepository;
using Store.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Store.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ELearningDbContext context;
		public ICacheRepository cacheRepository { get; set; }
		public ICartRepository CartRepository { get; set; }

        private Hashtable repositories;

        public UnitOfWork(ELearningDbContext context,
            ICacheRepository cacheRepository,
			ICartRepository cartRepository
            )
		{
			this.context = context;
			this.cacheRepository = cacheRepository;
			CartRepository = cartRepository;
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

        public ILectureComponentsRepository<TEntity> LectureComponentsRepository<TEntity>() where TEntity : BaseEntity
        {
            return new LectureComponentsRepository<TEntity>(context);
        }
    }
}
