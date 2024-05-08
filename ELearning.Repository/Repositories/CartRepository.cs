using ELearning.BLL.Interfaces;
using StackExchange.Redis;
using ELearning.Data.Entities;
using System.Text.Json;
using System.Security.Claims;

namespace Store.Repository.BasketRepository
{
	public class CartRepository : ICartRepository
	{
		private readonly IDatabase database;
		private readonly ICacheRepository<Cart> cacheRepository;

		public CartRepository(IConnectionMultiplexer redis, ICacheRepository<Cart> cacheRepository)
		{
			database = redis.GetDatabase();
			this.cacheRepository = cacheRepository;
		}
		public async Task<bool> DeleteBasketAsync(string id)
			=> await database.KeyDeleteAsync(id);

		public async Task<Cart> GetBasketAsync(string id)//userid
		{
			//var data = await database.StringGetAsync(id);
			var data = await cacheRepository.GetCacheResponseAsync(id);
			if (data is null)
				return new Cart() { Id = id };

			return data;
		}

		public async Task<Cart> UpdateBasketAsync(Cart cart)
		{
			var isCreated = await database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));

			if (!isCreated)
				return new Cart();

			return await GetBasketAsync(cart.Id);

		}
		public async Task CreateCart(string id)
			=> await cacheRepository.SetCacheResponseAsync(id, new Cart(), TimeSpan.FromDays(30));


		public bool InCart(Cart cart, int courseId)
			=> cart.Courses.Any(course => course.Id == courseId);

		public void AddToCart(Cart cart , CartCourse course)
			=> cart.Courses.Add(course);

        public void RemoveFromCart(Cart cart, int courseId)
			=> cart.Courses = cart.Courses.Where(course=>course.Id != courseId).ToList();
    }
}
