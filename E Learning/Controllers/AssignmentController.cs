using AutoMapper;
using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.Data.Entities;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AssignmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult Index(int courseId)
        {
            var assignments = unitOfWork.AssignmentRepository.GetAssignmentsByCourseId(courseId);
            ViewBag.CourseId = courseId;
            HttpContext.Session.SetInt32("CourseId", courseId);
            return View(assignments);
        }
        public IActionResult Create(int courseId)
        {
            return View(new AssignmentViewModel { CourseId = courseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Instructor)]


        public async Task<IActionResult> Create(AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedAssignment = mapper.Map<Assignment>(model);
                await unitOfWork.Reposirory<Assignment>().AddAsync(mappedAssignment);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { courseId = model.CourseId });
            }

            return View(model);
        }
        public async Task<IActionResult> SubmitAssignments(int assignmentId)
        {
            var assignment = await unitOfWork.Reposirory<Assignment>().GetByIdAsync(assignmentId);
            return View(new StudentAssignmentViewModel { AssignmentId = assignmentId, Description = assignment.Description });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SubmitAssignments(StudentAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var studentAssignment = new StudentAssignment
                {
                    AssignmentId = model.AssignmentId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Path = DocumentSetting.UploadFile(model.Assignment, "Assignments")
                };

                await unitOfWork.Reposirory<StudentAssignment>().AddAsync(studentAssignment);
                await unitOfWork.CompleteAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Update(int id)
        {
            var assignment = unitOfWork.Reposirory<Assignment>().GetById(id);

            if (assignment == null)
                return NotFound();
            var model = mapper.Map<AssignmentViewModel>(assignment);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = Roles.Instructor)]


        public async Task<IActionResult> Update(AssignmentViewModel model)
        {

            if (ModelState.IsValid)
            {
                var assignment = mapper.Map<Assignment>(model);
                unitOfWork.Reposirory<Assignment>().Update(assignment);
                await unitOfWork.CompleteAsync();

                return RedirectToAction("Index", "Assignment", new { courseId = model.CourseId });
            }
            return View();
        }
        [Authorize(Roles = Roles.Instructor)]


        public async Task<IActionResult> Delete(int id, int courseId)
        {
            var assignment = unitOfWork.Reposirory<Assignment>().GetById(id);

            if (assignment == null)
                return NotFound();

            unitOfWork.Reposirory<Assignment>().Delete(assignment);
            await unitOfWork.CompleteAsync();
            return RedirectToAction("Index", "Assignment", new { courseId = courseId });
        }

        public IActionResult Submissions(int id)
        {
            var res = unitOfWork.AssignmentRepository.GetStudentsSubmissionsForAssignment(id);

            return View(res);
        }

        public IActionResult Details(int id)// studentassignment Id
        {
            var sa = unitOfWork.Reposirory<StudentAssignment>().GetById(id);
            if (sa == null)
                return NotFound();

            // mapping
            var res = mapper.Map<EvaluateAssignmentViewModel>(sa);


            return View(res);
        }

        public FileResult Download(string fileName)
        {
            string path = DocumentSetting.GetAssignmentPath(fileName);

            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
