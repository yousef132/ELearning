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
		public ICartRepository CartRepository { get; set; }
        public IAttachmentRepository AttachmentRepository { get ; set ; }
        public IExamRepository ExamRepository { get ; set ; }
        public IAssignmentRepository AssignmentRepository { get ; set ; }
        public IStudentCourseRepository studentCourseRepository { get; set; }

        private Hashtable repositories;

        public UnitOfWork(ELearningDbContext context,
			ICartRepository cartRepository,
            IAttachmentRepository attachmentRepository,
            IExamRepository examRepository,
            IAssignmentRepository assignmentRepository,
            IStudentCourseRepository studentCourseRepository)
		{
			this.context = context;
			this.CartRepository = cartRepository;
            this.AssignmentRepository = assignmentRepository;
            this.ExamRepository = examRepository;
            this.AttachmentRepository = attachmentRepository;
            this.studentCourseRepository= studentCourseRepository;
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
