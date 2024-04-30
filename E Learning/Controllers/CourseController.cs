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
        public async Task<IActionResult> Index(CourseSpecifications courseSpecs)
        {
            return View(await GetCoursesWithSpecs(courseSpecs));
        }

        private async Task<IReadOnlyList<Course>> GetCoursesWithSpecs(CourseSpecifications courseSpecs)
        {

            //var coursess = await unitOfWork.Reposirory<Course>().GetAllAsync();
            var specs = new CourseWithSpecifications(courseSpecs);
            var courses = await unitOfWork
                                .Reposirory<Course>()
                                .GetWithSpecificationsAllAsync(specs);
            return courses;
        }
        public async Task <IActionResult> FilterSearchCourses(SpecificationsViewModel courseSpecs)
        {
            var specs = new CourseSpecifications
            {
                Levels = courseSpecs.Levels,
                Languages = courseSpecs.Languages,
                MinPrice = courseSpecs.MinPrice,
                MaxPrice = courseSpecs.MaxPrice,
                Name = courseSpecs.Name,
            };
            return PartialView(await GetCoursesWithSpecs(specs));
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
                    SkillLevel = course.SkillLevel,
                    Price = course.Price,
                    Language = course.Language,
                    Description = course.Description,
                    ImagePath = DocumentSetting.UploadFile(course.Image, "Images","course"),
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

            DocumentSetting.DeleteFile("Images","course", course.ImagePath);
            unitOfWork.Reposirory<Course>().Delete(course);
            await unitOfWork.CompleteAsync();
            return RedirectToAction("Courses", "Instructor");
        }

        public async Task<IActionResult> Update(int id)
        {
			var course = await unitOfWork.Reposirory<Course>().GetByIdAsync(id);

			if (course == null)
				return NotFound();

            var courseModel = new CourseViewModel
            {
                Name = course.Name,
                Description = course.Description,
                Price = course.Price,
                Duration = ((int)course.Duration.TotalHours),
                Language = course.Language,
                SkillLevel = course.SkillLevel,
            };

            return View(courseModel);
		}

        [HttpPost]
        public async Task<IActionResult>  Update(CourseViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Name = model.Name,  
                    Description = model.Description,
                    Price = model.Price,
                    Duration =new TimeSpan(model.Duration,0,0),
                    Language = model.Language,
                    SkillLevel = model.SkillLevel,
                };
                unitOfWork.Reposirory<Course>().Update(course);
                await unitOfWork.CompleteAsync();
                return RedirectToAction("Courses", "Instructor");
            }

            return View(model);

        }


    }
}
