using AutoMapper;
using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.BLL.Specifications.CourseSpecification;
using ELearning.BLL.Specifications.LectureSpecification;
using ELearning.DAL.Entities;
using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Reflection.Metadata;

namespace E_Learning.Controllers
{
	public class LectureController : Controller
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public LectureController(IUnitOfWork unitOfWork,IMapper mapper)
        {
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
        public async Task<IActionResult> Index(int id)//course id
		{
			var specs = new CourseWithSpecifications(id);
			// course Data With Included Lectures
			var course = await unitOfWork.Reposirory<Course>().GetWithSpecificationsByIdAsync(specs);
			TempData["CourseId"] = id;

			if (course == null)
				return NotFound();

			return View(course);
		}

        public FileResult Download(string fileName)
        {
            string path = DocumentSetting.GetPath(fileName);

			byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream",fileName);		
		}

        public async Task<IActionResult> OpenAttachment(int attachmentId)
        {
            var attachment = await unitOfWork.Reposirory<Attachment>().GetByIdAsync(attachmentId);
            return PartialView(attachment);
        }

        public IActionResult LectureAssignments(int id)//LectureId
		{
			var assignments = unitOfWork.AssignmentRepository.GetAssignmentsByCourseId(id);
						
			return View(assignments);
		}
		public IActionResult lectureExam(int id)//LectureId
		{
			var exams = unitOfWork
							.ExamRepository
							.GetExamsByCourseId(id);

			return View(exams);
		}
		
		public IActionResult LectureContent(int lectureId)//LectureId
		{
			var content = unitOfWork
							 .AttachmentRepository
                             .GetAttachmentsByLectureId(lectureId);

			return View(content);
		}

        public async Task<IActionResult> AddComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = mapper.Map<StudentLectureComment>(model);

                await unitOfWork.Reposirory<StudentLectureComment>().AddAsync(comment);
                await unitOfWork.CompleteAsync();
            }
            return View(model);
        }

        #region CRUD Operations
        public async Task<IActionResult> Delete(int id)
        {
            var specs = new LectureWithSpecification(id);
            var lecture = await unitOfWork.Reposirory<Lecture>().GetWithSpecificationsByIdAsync(specs);
            if (lecture is null)
                return BadRequest();

            unitOfWork.Reposirory<Lecture>().Delete(lecture);
            await unitOfWork.CompleteAsync();

            foreach (var att in lecture.Attachments)
            {
                DocumentSetting.DeleteFile("Videos", "Lectures", att.Path);
            }
            return RedirectToAction(nameof(Index), new { id = TempData["CourseId"] });
        }

        public async Task<IActionResult> Update(int id)//lecture id
        {
            var specs = new LectureWithSpecification(id);

            var lecture = await unitOfWork.Reposirory<Lecture>().GetWithSpecificationsByIdAsync(specs);
            if (lecture is null)
                return BadRequest();
            return View(lecture);
        }



        public IActionResult Create(int courseId)
        {
            return View(new LectureViewModel { CourseId = courseId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LectureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lecture = new Lecture()
                {
                    Name = model.LectureName,
                    CreatedAt = DateTime.Now,
                    CourseId = model.CourseId,
                };

                await unitOfWork.Reposirory<Lecture>().AddAsync(lecture);
                await unitOfWork.CompleteAsync();

                var attachment = new Attachment()
                {
                    Path = DocumentSetting.UploadFile(model.File, "Videos", "Lectures"),
                    LectureId = lecture.Id,
                    Type = Path.GetExtension(model.File.FileName),
                    Name = model.Name,
                };

                await unitOfWork.Reposirory<Attachment>().AddAsync(attachment);
                await unitOfWork.CompleteAsync();

                return RedirectToAction("Index", "Lecture", new { id = model.CourseId });
            }
            return View(model);
        }
        #endregion

    }
}
