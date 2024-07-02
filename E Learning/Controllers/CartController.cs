using AutoMapper;
using ELearning.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using System.Security.Claims;

namespace E_Learning.Controllers
{
	[Authorize]
    public class CartController : Controller
	{
		private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CartController(IUnitOfWork unitOfWork,IMapper mapper)
        {
			this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
		{
			return View(await GetCart());
		}
		private async Task<Cart> GetCart()
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = await unitOfWork.CartRepository.GetBasketAsync(userId);
			return cart;
        }

		public async Task<IActionResult> DeleteCartAsync()
		{
			 var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await unitOfWork.CartRepository.DeleteBasketAsync(userId);

			 return View();
		}

		public async Task<IActionResult> AddCourse(int courseId)
		{
           
			var course = await unitOfWork
                  .Reposirory<Course>()
                  .GetByIdAsync(courseId);

            if (course == null)
                return BadRequest();


            var cart = await GetCart();

			// check if course in cart
            bool inCart = unitOfWork.CartRepository.InCart(cart,courseId);

            if (inCart)
                return Json(new { status = false, message = "Course Already In Cart" });

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // check if user has bought ccourse
            var hasCourse = unitOfWork.studentCourseRepository.GetCourse(userId,courseId);
			if (hasCourse !=null)
                return Json(new { status = false, message = "You have already bought this course !" });



			var cartCourse =  mapper.Map<CartCourse>(course);

			cart.ShopingPrice += cartCourse.Price;

			unitOfWork.CartRepository.AddToCart(cart,cartCourse);

			await unitOfWork.CartRepository.UpdateBasketAsync(cart);

			return Json(new { status = true ,message = "Course Added To Cart"} );
		}
		
		public async Task<IActionResult> DeleteCourse(int courseId)
		{
            var course = await unitOfWork.Reposirory<Course>().GetByIdAsync(courseId);

            if (course == null)
                return NotFound();

            var cart = await GetCart();

		

			var cartCourse = mapper.Map<CartCourse>(course);

			cart.ShopingPrice -= cartCourse.Price;

			// removing course from cart, it handles all cases whether the course is in the cart or not 
			unitOfWork.CartRepository.RemoveFromCart(cart, cartCourse.Id);

			await unitOfWork.CartRepository.UpdateBasketAsync(cart);
			return Json(new { status = true });

		}
    }
}
