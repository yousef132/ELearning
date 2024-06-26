﻿using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.BasketRepository
{
	public interface ICartRepository
	{

		Task<Cart> GetBasketAsync(string id);
		Task<Cart> UpdateBasketAsync(Cart cart);

		Task<bool> DeleteBasketAsync(string id);
		Task CreateCart(string id);

		bool InCart(Cart cart, int courseId);
		void AddToCart(Cart cart, CartCourse course);

		void RemoveFromCart(Cart cart, int courseId);

    }
}
