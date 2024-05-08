using ELearning.BLL.Interfaces;
using ELearning.Data.Entities;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Repository.Repositories
{
	public class CacheRepository<T> : ICacheRepository<T>
	{
		private readonly IConfiguration configuration;
        private readonly IDatabase database;
		public CacheRepository(IConnectionMultiplexer redis,IConfiguration configuration)
        {
			this.configuration = configuration;
            database = redis.GetDatabase();
		}
        public async Task<T> GetCacheResponseAsync(string Key)
		{
			var cachedResponse = await database.StringGetAsync(Key);

			return JsonSerializer.Deserialize<T>(cachedResponse);

		}

		public async Task SetCacheResponseAsync(string Key, T response, TimeSpan timeToLive)
		{
			if (response is null)
				return;

			var serializedResponse = JsonSerializer.Serialize(response);
			await database.StringSetAsync(Key, serializedResponse, timeToLive);
		}
	}
}
