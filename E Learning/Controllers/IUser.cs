using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
	// instructor , student common Methods
	public interface IUser
	{
		Task<IReadOnlyList<Course>> GetUserCourses(string userId);
	}
}