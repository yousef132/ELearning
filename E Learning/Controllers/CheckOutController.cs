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

        public CheckOutController(IConfiguration configuration,IUnitOfWork unitOfWork)
        {
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> CheckOut()
        {
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];

            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            var domain = configuration["BaseUrl"];
            var options = new SessionCreateOptions 
            {
                SuccessUrl = domain + "CheckOut/OrderConfirmation",
                CancelUrl = domain + "CheckOut/PaymentFailed",
                LineItems = new List<SessionLineItemOptions>(),
                Mode= "payment",
               CustomerEmail = userEmail
            };

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var cart = await unitOfWork.CartRepository.GetBasketAsync(userId);
            foreach (var cartItem in cart.Courses)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long) cartItem.Price * 100,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = cartItem.Name,
                            Images = new List<string> { cartItem.ImagePath }
                        }
                    },
                    Quantity =1 ,
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            TempData["Session"] = session.Id;
            Response.Headers.Add("Location",session.Url);


            return new StatusCodeResult(303);
        }


        public IActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());


            if (session.PaymentStatus == "paid")
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                unitOfWork.CartRepository.DeleteBasketAsync(userId);

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
