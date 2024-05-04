using E_Commerce.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ELearning.Helper;
using ELearning.Models;
using System.Security.Claims;
using Store.Repository.BasketRepository;
using Store.Repository.Interfaces;
using ELearning.DAL.Context.Identity;
namespace E_Learning.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly ICartRepository cartRepository;
        private readonly IUnitOfWork unitOfWork;

        public SignInManager<ApplicationUser> SignInManager { get; set; }

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            this.configuration = configuration;
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email.Split('@')[0],
                    DisplayName = model.Name,
                    ImagePath = configuration["DefaultImage"]
                };

                // create kookie
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                // Seed Roles First
                await SignInManager.SignInAsync(user, false);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Student);
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is null)
                    ModelState.AddModelError("", "email Not Found");

                if (user is not null && await userManager.CheckPasswordAsync(user, model.Password))
                {   
                    await SignInManager.PasswordSignInAsync(user,model.Password,true,false);

                    if (await userManager.IsInRoleAsync(user, Roles.Admin))
                    {
                        return RedirectToAction("Dashboard","Admin");
                    }
                    else if(await userManager.IsInRoleAsync(user, Roles.Instructor))
                    {
                        return RedirectToAction("Dashboard", "Instructor");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                    ModelState.AddModelError("", "Wronge Password");
            }
            return View(model);
        }
        public async Task<IActionResult> Signout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is null)
                    ModelState.AddModelError("", "email Not Found");

                if (user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordLink = Url.Action("ResetPassword", "Account"
                        , new { Email = model.Email, Token = token }, Request.Scheme);

                    var email = new Email
                    {
                        Header = "Reset Password",
                        Body = resetPasswordLink,
                        To = model.Email
                    };
                    //send email
                    EmailSettings.SendEmail(email);
                    return RedirectToAction("CompletePassword");

                }
            }
            return View(model);
        }

        public IActionResult CompletePassword()
        {
            return View();
        }

        public IActionResult ResetPassword(string email, string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is null)
                    ModelState.AddModelError("", "email Not Found");

                if (user is not null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                        return RedirectToAction("Login");


                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
