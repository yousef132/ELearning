using ELearning.Data.Context;
using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Store.Repository.Interfaces;
using System.Reflection;

namespace Store.Repository.Repositories
{
    public class LectureComponentsRepository<T> : ILectureComponentsRepository<T> where T : BaseEntity
    {
        private readonly ELearningDbContext context;
        private readonly DbSet<T> _dbSet;
        private readonly PropertyInfo lectureIdProperty;

        public LectureComponentsRepository(ELearningDbContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
            lectureIdProperty = typeof(T).GetProperty("LectureId");

        }

        public ICollection<T> GetItemsByLectureId(int lectureId)
                => _dbSet
            .Where(item => (int)lectureIdProperty.GetValue(item) == lectureId)
            .ToList();
    }
}
