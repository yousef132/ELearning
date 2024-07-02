using ELearning.Data.Entities;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    [Authorize(Roles = Roles.Student)]
    public class StudentController : Controller, IUser
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [Authorize(Roles = Roles.Admin)]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetCourses()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var courses = await GetUserCourses(userId);
            return View(courses);
        }
        public async Task<IReadOnlyList<Course>> GetUserCourses(string userId)
        {
            // var specs = new StudentCourseSpecifications(userId);
            // var courses = await unitOfWork.Reposirory<StudentCourse>().GetWithSpecificationsAllAsync(specs);

            var courses = unitOfWork.studentCourseRepository.GetAllCourses(userId);

            return courses.Select(c => c.Course).ToList();
        }


        //public IActionResult Details()
        //{
        //    var studentCourses = GetCourses();  
        //}
    }
}
