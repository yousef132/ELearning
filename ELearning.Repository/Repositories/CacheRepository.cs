using ELearning.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;

namespace Store.Repository.Repositories
{
	public class CacheRepository : ICacheRepository
	{
		private readonly IConfiguration configuration;
        private readonly IDatabase database;
		public CacheRepository(IConnectionMultiplexer redis,IConfiguration configuration)
        {
			this.configuration = configuration;
            database = redis.GetDatabase();
		}
        public async Task<string> GetCacheResponseAsync(string Key)
		{
			var cachedResponse = await database.StringGetAsync(Key);

			if (string.IsNullOrEmpty(cachedResponse))
				return null;
			return cachedResponse.ToString();
		}

		public async Task SetCacheResponseAsync(string Key, object response, TimeSpan timeToLive)
		{
			if (response is null)
				return;

			var serializedResponse = JsonSerializer.Serialize(response);
			await database.StringSetAsync(Key, serializedResponse, timeToLive);
		}
	}
}
