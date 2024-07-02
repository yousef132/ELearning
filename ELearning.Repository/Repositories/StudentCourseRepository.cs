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


        public StudentCourse GetCourse(string userId, int courseId)
            => context.StudentCourses
                      .FirstOrDefault(sc => sc.UserId == userId && sc.CourseId == courseId);

        
        public double GetStudentCourseGrade(string userId, int courseId)
        => context.StudentCourses
                  .Where(sc => sc.UserId == userId && sc.CourseId == courseId)
                  .Select(x => x.TotalMark)
                  .FirstOrDefault();

    }
}
