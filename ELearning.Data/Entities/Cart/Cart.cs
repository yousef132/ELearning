using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Entities
{
	public class Cart
	{
		public string Id { get; set; }	
		public double ShopingPrice { get; set; }
		public List<CartCourse> Courses { get; set; } = new List<CartCourse>();
		public string? PaymentIntentId { get; set; }
		public string? ClientSecret { get; set; }
	}
}
