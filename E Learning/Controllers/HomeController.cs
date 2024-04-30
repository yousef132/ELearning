using E_Learning.Models;
using ELearning.Data.Context;
using ELearning.Data.Entities;
using ELearning.Helper;
using ELearning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Diagnostics;
using System.Security.Claims;

namespace ELearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger ,
            UserManager<ApplicationUser> userManager 
            ,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var instructorsTask = userManager.GetUsersInRoleAsync(Roles.Instructor);
            var instructors = await instructorsTask;

            var studentsTask = userManager.GetUsersInRoleAsync(Roles.Student);
            var students = await studentsTask;


            var courses = await unitOfWork
                               .Reposirory<Course>()
                               .GetAllAsync();
           
            var HomeViewModel = new HomeViewModel
            {
                Instructors = instructors,
                courses = courses,
                Students = students.Count(),
            };
            

            return View(HomeViewModel);
        }

        public  IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
