using E_Learning.Models;
using ELearning.BLL.Specifications.CourseSpecification;
using ELearning.Data.Context;
using ELearning.Data.Entities;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    [Authorize(Roles = Roles.Instructor)]   
    public class InstructorController : Controller , IUser
    {
		private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public InstructorController(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        public  IActionResult Index()
        {
            var instructors =  userManager.GetUsersInRoleAsync(Roles.Instructor).Result;

            return View(instructors);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id) 
        {
            if (id is null)
                return BadRequest();
            var instructor  = await userManager.FindByIdAsync(id);

            var coursespcs = new CourseSpecifications() { UserId = id };

            ViewBag.Courses = await GetUserCourses(id);

			if (instructor == null)
                return NotFound();


            return View(instructor);
        }

        public async Task<IReadOnlyList<Course>> GetUserCourses(string userId)
        {

			var coursespecs = new CourseSpecifications { UserId = userId };

			var specs = new CourseWithSpecifications(coursespecs);

			return  await unitOfWork.Reposirory<Course>().GetWithSpecificationsAllAsync(specs);
		}
		
        public async Task<IActionResult> Courses()
		{
			var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
			var courses = await GetUserCourses(userId);
			return View(courses);
		}

        [HttpGet]
        public async Task<IActionResult> AddAttachment(int id)
        {
            var specs = new CourseWithSpecifications(id);
            var course = await unitOfWork.Reposirory<Course>().GetWithSpecificationsByIdAsync(specs);

            if (course == null) 
                return NotFound();
            return View(course.Lectures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAttachment(AttachmentViewModel model)
        {
            
            return View();
        }


    }
}
