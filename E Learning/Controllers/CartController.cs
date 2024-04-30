using ELearning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class CartController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public CartController(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}
        public async Task<IActionResult> Index()
		{
			return View(await GetCart());
		}
		private async Task<Cart> GetCart()
		{
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var cart = await unitOfWork.CartRepository.GetBasketAsync(userId);
			return cart;
        }

		public async Task<IActionResult> DeleteCartAsync()
		{
			 var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

			 await unitOfWork.CartRepository.DeleteBasketAsync(userId);

			 return View();
		}


		public async Task<IActionResult> AddCourse(int courseId)
		{
			var cart = await GetCart();

            bool inCart = cart.Courses.Any(c => c.Id == courseId);

            if (inCart)
                return Json(new { status = false });

            var course = await unitOfWork
							  .Reposirory<Course>()
							  .GetByIdAsync(courseId);
			if (course == null)
				return BadRequest();

			var cartCourse = new CartCourse
			{
				Name = course.Name,
				Id = course.Id,
				Price = course.Price,
				ImagePath = course.ImagePath,
				Description = course.Description,	
			};
			cart.ShopingPrice += cartCourse.Price;

			cart.Courses.Add(cartCourse);

			await unitOfWork.CartRepository.UpdateBasketAsync(cart);

			return Json(new { status = true } );
		}
		
		public async Task<IActionResult> DeleteCourse(int courseId)
		{
			var cart = await GetCart();

			var course = await unitOfWork.Reposirory<Course>().GetByIdAsync(courseId);

			if (course == null)
				return NotFound();

			var cartCourse = new CartCourse
			{
				Id = course.Id,
				Name = course.Name,
				Price = course.Price,
				ImagePath = course.ImagePath,
				Description = course.Description

			};
			cart.ShopingPrice -= cartCourse.Price;
            // removing course from cart, it handles all cases whether the course is in the cart or not 
            cart.Courses = cart.Courses.Where(c => c.Id != cartCourse.Id).ToList();

			await unitOfWork.CartRepository.UpdateBasketAsync(cart);
			return Json(new { status = true });

		}
    }
}
