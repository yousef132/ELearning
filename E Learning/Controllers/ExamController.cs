using AutoMapper;
using E_Learning.Models;
using ELearning.BLL.Interfaces;
using ELearning.BLL.Specifications.ExamSpecificatoin;
using ELearning.Data.Entities;
using ELearning.Data.Entities.Question;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using Stripe;
using System.Net.Mail;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class ExamController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ExamController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult Index(int id)//courseId
        {
            var exams = unitOfWork.ExamRepository.GetExamsByCourseId(id);
            ViewBag.CourseId = id;
            TempData["CourseId"] = id;
            return View(exams);
        }

        public async Task<IActionResult> CourseExams(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var examspecs = new ExamSpecifications() { CourseId = courseId };
            var specs = new ExamWithSpecifications(examspecs);
            var courseAllExams = await unitOfWork.Reposirory<Exam>().GetWithSpecificationsAllAsync(specs);
            var completedExams = await unitOfWork.Reposirory<StudentExam>().GetAllAsync();
            // completed exams for this user
            completedExams = completedExams.Where(se => se.UserId == userId).ToList();
            ViewBag.completedExams = completedExams;
            return PartialView(courseAllExams);
        }

        public IActionResult Create(int id)//LectureId
        {
            return View(new ExamViewModel { CourseId = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamViewModel examModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam()
                {
                    Name = examModel.Name,
                    TimedEntity = new TimedEntity
                    {
                        Open = examModel.Open,
                        Close = examModel.Close,
                        Grade = examModel.Grade,
                    },
                    CourseId = examModel.CourseId.Value
                };
                // create exam
                await unitOfWork.Reposirory<Exam>().AddAsync(exam);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index), new { id = exam.CourseId });
            }
            return View(examModel);
        }


        public IActionResult AddQuestion(int id)//Examid
        {
            return View(new QuestionViewModel { ExamId = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddQuestion(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedQuestion = mapper.Map<BaseQuestion>(model);

                await unitOfWork.Reposirory<BaseQuestion>().AddAsync(mappedQuestion);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(AddQuestion), new { id = mappedQuestion.ExamId });
            }
            return View(model);
        }


        public async Task<IActionResult> StartExam(int id)//examId
        {
            var examSpecs = new ExamSpecifications() { ExamId = id };
            var specs = new ExamWithSpecifications(examSpecs);
            // Get Exam With Included Questions
            var exam = await unitOfWork.Reposirory<Exam>().GetWithSpecificationsByIdAsync(specs);
            TempData["ExamId"] = id;
            ViewBag.Exam = exam;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompleteExam(List<CompleteExamViewModel> model)
        {
            if (ModelState.IsValid)
            {
                var studentAnswer = mapper.Map<List<StudentAnswer>>(model);
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int examId = (int)TempData["ExamId"];
                var exam = await unitOfWork.Reposirory<Exam>().GetByIdAsync(examId);  

                foreach (var sa in studentAnswer)
                {
                    sa.UserId = userId;
                    await unitOfWork.Reposirory<StudentAnswer>().AddAsync(sa);
                    await unitOfWork.CompleteAsync();
                }
                var studentExam = new StudentExam
                {
                    UserId = userId,
                    Grade = CalculateGrade(studentAnswer,exam.TimedEntity.Grade),
                    SubmittedAt = DateTime.Now,
                    ExamId = examId
                };
                await unitOfWork.Reposirory<StudentExam>().AddAsync(studentExam);
                await unitOfWork.CompleteAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private double CalculateGrade(List<StudentAnswer> studentAnswer, double examGrade)
        {
            var correctAnswers = studentAnswer.Count(sa => sa.AnswerIsCorrect == true);
            if (correctAnswers == 0)
                return 0;
            var pointGrade = examGrade / studentAnswer.Count() ;

            return (double)pointGrade * correctAnswers;
        }


        public async Task<IActionResult> DeleteExam(int examId)
        {
            var exam = await unitOfWork.Reposirory<Exam>().GetByIdAsync(examId);
            if(exam == null)
                return NotFound();
            unitOfWork.Reposirory<Exam>().Delete(exam);
            await unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index),new {courseId = TempData["CourseId"] });
        }
    }
}
