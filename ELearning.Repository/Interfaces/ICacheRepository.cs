using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Interfaces
{
	public interface ICacheRepository
	{
		Task SetCacheResponseAsync(string Key, object response, TimeSpan timeToLive);
		Task<string> GetCacheResponseAsync(string Key);	
	}
}
