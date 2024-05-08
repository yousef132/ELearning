using AutoMapper;
using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.BLL.Specifications;
using ELearning.BLL.Specifications.CourseSpecification;
using ELearning.BLL.Specifications.StudentCourseSpecification;
using ELearning.Data.Context;
using ELearning.Data.Entities;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Repository.Interfaces;
using System.Drawing;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class CourseController : Controller 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CourseSpecifications courseSpecs)
        {
            var courses = await GetCoursesWithSpecs(courseSpecs);
            int pageSize = 4;
            return View(PaginatedList<Course>.CreateAsync(courses, 1, pageSize));
        }

        public async Task<IActionResult> CourseContent(int id)
        {

            var specs = new CourseWithSpecifications(id);
            var course = await unitOfWork.Reposirory<Course>().GetWithSpecificationsByIdAsync(specs);
            return View(course);
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

            var specs = mapper.Map<CourseSpecifications>(courseSpecs);

            if (courseSpecs.PageIndex < 1)
                courseSpecs.PageIndex = 1;

            var courses = await GetCoursesWithSpecs(specs);
            int pageSize = 4;
            return PartialView(PaginatedList<Course>.CreateAsync(courses, courseSpecs.PageIndex, pageSize));
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


        public async Task<IActionResult> GetCoureParticipants(int courseId)
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var specs = new StudentCourseSpecification() {  CourseId = courseId }; 
            var studentCourseSpecs = new StudentWithCourseWtihSpecification(specs); 
            var studentCourses =await unitOfWork.Reposirory<StudentCourse>().GetWithSpecificationsAllAsync(studentCourseSpecs);
 
            return PartialView(studentCourses);
        }


        #region CRUD Operations

        [Authorize(Roles = Roles.Instructor)]
        public IActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(CourseViewModel courseModel)
        {
            if (ModelState.IsValid)
            {

                var course = mapper.Map<Course>(courseModel);

                course.ImagePath = DocumentSetting.UploadFile(courseModel.Image, "Images", "course");
                course.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await unitOfWork.Reposirory<Course>().AddAsync(course);
                await unitOfWork.CompleteAsync();
                return RedirectToAction("Courses", "Instructor");
            }
            return View(courseModel);
        }
        [Authorize(Roles = Roles.Instructor)]

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
        [Authorize(Roles = Roles.Instructor)]

        public async Task<IActionResult> Update(int id)
        {
			var course = await unitOfWork.Reposirory<Course>().GetByIdAsync(id);

			if (course == null)
				return NotFound();
            //course -> courseviewmodel
            var courseModel = mapper.Map<CourseViewModel>(course);
            return View(courseModel);
		}
        [Authorize(Roles = Roles.Instructor)]

        [HttpPost]
        public async Task<IActionResult>  Update(CourseViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var course = mapper.Map<Course>(model);
                unitOfWork.Reposirory<Course>().Update(course);
                await unitOfWork.CompleteAsync();
                return RedirectToAction("Courses", "Instructor");
            }

            return View(model);
        }
        #endregion


    }
}
