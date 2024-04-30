using ELearning.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Store.Repository.BasketRepository;
using Stripe;

namespace ELearning.BLL.Repositories
{
    //public class PaymentRepository : IPaymentRepository
    //{
    //    private readonly IConfiguration configuration;
    //    private readonly ICartRepository cartRepository;

    //    public PaymentRepository(IConfiguration configuration, ICartRepository cartRepository)
    //    {
    //        this.cartRepository = cartRepository;
    //    }
    //    public async Task<CartDto> CreateOrUpdatePaymentIntentForExsitingOrder(CartDto input)
    //    {
    //        StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
    //    }

    //    public Task<CartDto> CreateOrUpdatePaymentIntentForNewOrder(string basketId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<OrderResultDto> UpdateOrderPaymentFailed(string paymentIntentId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<OrderResultDto> UpdateOrderPaymentSucceded(string paymentIntentId)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
