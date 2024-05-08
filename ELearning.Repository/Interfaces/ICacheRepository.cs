using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Interfaces
{
	public interface ICacheRepository<T>
	{
		Task SetCacheResponseAsync(string Key, T response, TimeSpan timeToLive);
		Task<T> GetCacheResponseAsync(string Key);	
	}
}
