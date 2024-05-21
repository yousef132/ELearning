using ELearning.BLL.Interfaces;
using ELearning.Data.Context;
using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELearning.BLL.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ELearningDbContext context;

        public StudentCourseRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public IReadOnlyList<StudentCourse> GetAllCourses(string userId)
          => context.StudentCourses
                    .Where(sc => sc.UserId == userId)
                    .Include(sc => sc.Course)
                    .ToList();


        public bool HasCourse(string userId, int courseId)
            => context.StudentCourses
                      .Any(sc => sc.UserId == userId && sc.CourseId == courseId);
    }
}
