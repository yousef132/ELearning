using ELearning.BLL.Interfaces;
using StackExchange.Redis;
using Store.Data.Entities;
using System.Text.Json;

namespace Store.Repository.BasketRepository
{
	public class CartRepository : ICartRepository
	{
		private readonly IDatabase database;
		private readonly ICacheRepository cacheRepository;

		public CartRepository(IConnectionMultiplexer redis, ICacheRepository cacheRepository)
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
			if (string.IsNullOrEmpty(data))
				return new Cart() { Id = id };

			return JsonSerializer.Deserialize<Cart>(data);
		}

		public async Task<Cart> UpdateBasketAsync(Cart cart)
		{
			var isCreated = await database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart),TimeSpan.FromDays(30));

			if (!isCreated)
				return new Cart();

			return await GetBasketAsync(cart.Id);

		}

		public async Task CreateCart(string id)
		=>await cacheRepository.SetCacheResponseAsync(id, new Cart(), TimeSpan.FromDays(30));
		
	}
}
