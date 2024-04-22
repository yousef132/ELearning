using ELearning.BLL.Specifications.LectureSpecification;
using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;

namespace E_Learning.Controllers
{
	public class LectureController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public LectureController(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}
        public IActionResult Index(int id)
		{
			return View();
		}


		public async Task<IActionResult> Delete(int id)
		{
			var lecture = await unitOfWork.Reposirory<Lecture>().GetByIdAsync(id);
			if(lecture is null)
				return BadRequest();

			unitOfWork.Reposirory<Lecture>().Delete(lecture);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update (int id)//lecture id
		{
			var specs = new LectureWithSpecification(id);
			var lecture = await unitOfWork.Reposirory<Lecture>().GetWithSpecificationsByIdAsync(specs);
			if (lecture is null)
				return BadRequest();
			return View(lecture);
		}
	}
}
