using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.Data.Context;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Repositories;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    [Authorize(Roles =Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Instructors()
        {
            var instructorsTask = userManager.GetUsersInRoleAsync(Roles.Instructor);
            var instructors = await instructorsTask;

            return View(instructors);
        }
        public  IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInstructor(CreateInstructorViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var instructor = new ApplicationUser()
                {
                    Email = model.Email,
                    DisplayName = model.Name,
                    ImagePath = DocumentSetting.UploadFile(model.Image,"Images", "User"),
                    UserName = model.Email.Split('@')[0]
                    
                };
    
                 var result = await userManager.CreateAsync(instructor,model.Password);
                if (!result.Succeeded) 
                {
                    DocumentSetting.DeleteFile("Images", "User", instructor.ImagePath);
                    //await userManager.AddClaimAsync(instructor, new Claim("Title", model.Title));
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                await userManager.AddToRoleAsync(instructor,Roles.Instructor);
                TempData["Add"] = "Instructor Added Successfully";
                return RedirectToAction(nameof(Instructors));
            }

            return View(model);
		}


        public async Task<IActionResult> Delete(string id)
        {

            var instructor = await userManager.FindByIdAsync(id);
            if (instructor == null)
                return BadRequest();
            DocumentSetting.DeleteFile("Images", "User",instructor.ImagePath);
            await userManager.DeleteAsync(instructor);
            TempData["Delete"] = "Instructor Deleted Successfuly";

            return RedirectToAction(nameof(Instructors));
        }



        public async Task< IActionResult> Update(string id)
        {

			var instructor = await userManager.FindByIdAsync(id);

            if(instructor == null)
                return BadRequest();

            var instructorViewModel = new UpdateInstructorViewModel
            {
                Name = instructor.DisplayName,
                ImagePath = instructor.ImagePath,
                Email = instructor.Email,
                Id = instructor.Id,
            };
            return View(instructorViewModel);
		}
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateInstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var instructor = await userManager.FindByIdAsync(model.Id);
                if (instructor is null)
                    return BadRequest();

                instructor.DisplayName = model.Name;
                instructor.Email = model.Email; 

                bool hasImage = model.Image is not null;

                if (hasImage)
                {
					DocumentSetting.DeleteFile("Images","User", model.ImagePath);// delete old image
					instructor.ImagePath = DocumentSetting.UploadFile(model.Image,"Images", "User");// add new image
				}
                await userManager.UpdateAsync(instructor);
				TempData["Update"] = "Instructor Updated Successfuly";

				return RedirectToAction(nameof(Instructors));
            }
            return View(model);
        }

    }
}
