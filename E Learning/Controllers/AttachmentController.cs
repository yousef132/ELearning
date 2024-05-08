using AutoMapper;
using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;

namespace E_Learning.Controllers
{
	public class AttachmentController : Controller
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public AttachmentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
        public IActionResult Index(int id)//lectureId
		{
			var attachments = unitOfWork.AttachmentRepository.GetAttachmentsByLectureId(id);

			return View(attachments);
		}
		public IActionResult Create(int id)//lectureId
		{
			return View(new AttachmentViewModel { LectureId = id});
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create (AttachmentViewModel attachmentModel)
		{
			if (ModelState.IsValid)
			{
				var attachment = new Attachment()
				{
					Name = attachmentModel.Name,
					LectureId = attachmentModel.LectureId.Value,
					Path = DocumentSetting.UploadFile(attachmentModel.Attachment, "Videos", "Lectures"),
					Type = Path.GetExtension(attachmentModel.Attachment.FileName),

                };
				await unitOfWork.Reposirory<Attachment>().AddAsync(attachment);
				await unitOfWork.CompleteAsync();
				return RedirectToAction("Update", "Lecture", new {id = attachment.LectureId});
			}
			return View(attachmentModel);
		}
		public async Task<IActionResult> Delete(int id)
		{

			var attachment = await unitOfWork.Reposirory<Attachment>().GetByIdAsync(id);
			if (attachment is null)
				return BadRequest();
		    unitOfWork.Reposirory<Attachment>().Delete(attachment);
			await unitOfWork.CompleteAsync();
			return RedirectToAction("Update", "Lecture");
		}

		public async Task<IActionResult> Update(int id)//AttachmentId
		{
			var attachment = await unitOfWork.Reposirory<Attachment>().GetByIdAsync(id);
			if (attachment is null)
				return BadRequest();

			var attVM = new AttachmentViewModel
			{
				Name = attachment.Name,
				LectureId = attachment.LectureId,
			};
			return View(attachment);
		}
		[HttpPost]
		public IActionResult Update(AttachmentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var attachemnt = new Attachment
				{
					Name = model.Name,
					LectureId = model.LectureId.Value,
					Path = DocumentSetting.UploadFile(model.Attachment, "Video", "lectures")
				};
            }
			return View(model);
		}
	}
}
