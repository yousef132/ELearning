using AutoMapper;
using E_Learning.Models;
using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;

namespace E_Learning.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AssignmentController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult Index(int courseId)
        {
            var assignments = unitOfWork.AssignmentRepository.GetAssignmentsByCourseId(courseId);
            ViewBag.CourseId = courseId;
            return View(assignments);
        }


        public IActionResult Create(int courseId)
        {
            return View(new AssignmentViewModel { CourseId = courseId});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedAssignment = mapper.Map<Assignment>(model);
               await unitOfWork.Reposirory<Assignment>().AddAsync(mappedAssignment);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new {courseId = model.CourseId});
            }

            return View(model);
        }


        public IActionResult SubmitAssignments (int assignmentId)
        {

            return PartialView(new StudentAssignmentViewModel { AssignmentId = assignmentId});
        }
        
        public IActionResult SubmitAssignments (StudentAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
              
            }
            return PartialView(model);
        }

    }
}
