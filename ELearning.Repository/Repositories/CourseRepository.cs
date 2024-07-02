using ELearning.BLL.Interfaces;
using ELearning.Data.Context;

namespace ELearning.BLL.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private readonly ELearningDbContext context;

		public CourseRepository(ELearningDbContext context)
		{
			this.context = context;
		}

		public int GetNumberOfCourses()
		 => context.Courses.Count();


		public IQueryable<Tuple<string, int>> GetNumberOfSellingForEachCourse()
		=> from sc in context.StudentCourses
		   join c in context.Courses on sc.CourseId equals c.Id
		   group c by c.Name into courseGroup
		   select new Tuple<string, int>(
			   courseGroup.Key.ToString(),
			   courseGroup.Count()
		   );

		public int GetNumberOfSoldCourses() => context.StudentCourses.Count();
	}
}
