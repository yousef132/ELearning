using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;

        public CheckOutController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> CheckOut()
        {
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];

            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var domain = configuration["BaseUrl"];
            var options = new SessionCreateOptions
            {
                //  SuccessUrl = domain + "https://localhost:7122/CheckOut/OrderConfirmation",
                SuccessUrl = domain + "CheckOut/OrderConfirmation",
                //  CancelUrl = domain + "https://localhost:7122/CheckOut/PaymentFailed",
                CancelUrl = domain + "CheckOut/PaymentFailed",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                CustomerEmail = userEmail
            };

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = await unitOfWork.CartRepository.GetBasketAsync(userId);
            var courses = new List<int>();
            foreach (var cartItem in cart.Courses)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)cartItem.Price * 100,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = cartItem.Name
                        }
                    },
                    Quantity = 1,
                };
                options.LineItems.Add(sessionLineItem);
                courses.Add(cartItem.Id);
            }
            TempData[userId] = courses;

            var service = new SessionService();
            Session session = service.Create(options);
            TempData["Session"] = session.Id;
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }


        public async Task<IActionResult> OrderConfirmation()
        {
            var service = new SessionService();
            string id = TempData["Session"].ToString();
            Session session = service.Get(id);


            if (session.PaymentStatus == "paid")
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var courses = TempData[userId] as IEnumerable<int>; ;

                foreach (var courseId in courses)
                {
                    await unitOfWork.Reposirory<StudentCourse>().AddAsync(new StudentCourse { CourseId = courseId, UserId = userId });
                    await unitOfWork.CompleteAsync();
                }

                await unitOfWork.CartRepository.DeleteBasketAsync(userId);

                return View();
            }
            return RedirectToAction(nameof(PaymentFailed));
        }
        public IActionResult PaymentFailed()
        {
            return View();
        }
    }
}
