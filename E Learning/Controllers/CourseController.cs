using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.BLL.Specifications.CourseSpecification;
using ELearning.Data.Entities;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class CourseController : Controller 
    {
        private readonly IUnitOfWork unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchValue = "")
        {
            var courseSpecs = new CourseSpecifications() { Name = searchValue };

            var specs = new CourseWithSpecifications(courseSpecs);

            var courses = await unitOfWork.Reposirory<Course>().GetWithSpecificationsAllAsync(specs);

            return View(courses);
        }


        public async Task<IActionResult> Details (int Id)
        {
            var coursespecs = new CourseSpecifications() { CourseId = Id };
            var specs = new CourseWithSpecifications(coursespecs);

            var course = await unitOfWork.Reposirory<Course>().GetWithSpecificationsByIdAsync(specs);

            if(course == null)
                return BadRequest();

            return View(course);    
        }

        [Authorize(Roles = Roles.Instructor)]

        public IActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                var courser = new Course()
                {
                    Name = course.Name,
                    Duration = new TimeSpan(course.Duration,0,0),
                    NumberOfLectures = course.Lectures,
                    SkillLevel = course.SkillLevel,
                    Price = course.Price,
                    Language = course.Language,
                    Description = course.Description,
                    ImagePath = DocumentSetting.UploadFile(course.Image, "course"),
                    UserId= userId
                };
                TempData["AddCourse"] = "Course Added Successfully";
                await unitOfWork.Reposirory<Course>().AddAsync(courser);
                await unitOfWork.CompleteAsync();
                return RedirectToAction("Courses", "Instructor");
            }
            return View(course);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await unitOfWork.Reposirory<Course>().GetByIdAsync(id);
            if (course is null)
                return NotFound();

            DocumentSetting.DeleteFile("course", course.ImagePath);
            unitOfWork.Reposirory<Course>().Delete(course);
            await unitOfWork.CompleteAsync();
            return RedirectToAction("Courses", "Instructor");
        }

    }
}
