using ELearning.Data.Entities;

namespace E_Learning.Models
{
    public class CartViewModel
    {
        public decimal ShopingPrice { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
