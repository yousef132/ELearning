﻿using AutoMapper;
using E_Commerce.Helper;
using E_Learning.Models;
using ELearning.DAL.Context.Identity;
using ELearning.Data.Context;
using ELearning.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mono.TextTemplating;
using Store.Repository.Repositories;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly ELearningDbContext context;

        public AdminController(UserManager<ApplicationUser> userManager
            , IMapper mapper,ELearningDbContext context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
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
        public IActionResult AddInstructor()
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
                    DisplayName = model.DisplayName,
                    ImagePath = DocumentSetting.UploadFile(model.Image, "Images", "User"),
                    UserName = model.Email.Split('@')[0]
                };
                instructor = mapper.Map<ApplicationUser>(instructor);
                var result = await userManager.CreateAsync(instructor, model.Password);
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
                await userManager.AddToRoleAsync(instructor, Roles.Instructor);
                return RedirectToAction(nameof(Instructors));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {

            var instructor = await userManager.FindByIdAsync(id);
            if (instructor == null)
                return BadRequest();
            DocumentSetting.DeleteFile("Images", "User", instructor.ImagePath);
            await userManager.DeleteAsync(instructor);

            return RedirectToAction(nameof(Instructors));
        }
        

        public async Task<IActionResult> Update(string id)
        {

            var instructor = userManager.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
            
            if (instructor == null)
                return BadRequest();

            var mappedInstructor = mapper.Map<UpdateInstructorViewModel>(instructor);
            return View(mappedInstructor);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateInstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isxist = await userManager.Users.AnyAsync(u => u.Id == model.Id);
              
                if (!isxist)
                    return BadRequest();

                var instructor = await userManager.FindByIdAsync(model.Id);

                bool hasImage = model.Image is not null;

                if (hasImage)
                {
                    DocumentSetting.DeleteFile("Images", "User", model.ImagePath);// delete old image
                    model.ImagePath = DocumentSetting.UploadFile(model.Image, "Images", "User");// add new image
                }

                instructor = mapper.Map(model, instructor);   

                var res = await userManager.UpdateAsync(instructor);
                return RedirectToAction(nameof(Instructors));
            }
            return View(model);
        }

    }
}
