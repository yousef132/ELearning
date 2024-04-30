using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.BLL.Specifications.CourseSpecification;
using ELearning.BLL.Specifications.LectureSpecification;
using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Reflection.Metadata;

namespace E_Learning.Controllers
{
	public class LectureController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public LectureController(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}
        public async Task<IActionResult> Index(int id)//course id
		{

			var specs = new CourseWithSpecifications(id);
			// courser Data With Included Lectures
			var course = await unitOfWork.Reposirory<Course>().GetWithSpecificationsByIdAsync(specs);
			TempData["CourseId"] = id;
			if (course == null)
				return NotFound();
			return View(course);
		}


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

		public async Task<IActionResult> Update (int id)//lecture id
		{
			var specs = new LectureWithSpecification(id);

			var lecture = await unitOfWork.Reposirory<Lecture>().GetWithSpecificationsByIdAsync(specs);
			if (lecture is null)
				return BadRequest();
			return View(lecture);
		}

		public IActionResult Create(int courseId)
		{
			return View(new LectureViewModel { CourseId = courseId});
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
					Type  = Path.GetExtension(model.File.FileName),
                    Name = model.FileName,
				};

				await unitOfWork.Reposirory<Attachment>().AddAsync(attachment);
				await unitOfWork.CompleteAsync();

				return RedirectToAction("Index", "Lecture", new { id = model.CourseId });
			}
			return View(model);
		}



		//[HttpGet]
		//public async Task<IActionResult> Update(int id)
		//{

		//	var specs = new CourseWithSpecifications(id);
		//	// courser Data With Included Lectures
		//	var course = await unitOfWork.Reposirory<Course>().GetWithSpecificationsByIdAsync(specs);

		//	if (course == null)
		//		return NotFound();

		//	return View(course);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult ManageLecture(AttachmentViewModel model)
		//{
		//	return View();
		//}
	}
}
