using System;
using System.Runtime.Caching;

namespace Store.Common.Helper
{
	public static class CacheHelper
	{
		public static T GetObjectFromCache<T>(string key) where T : class
		{
			T result = null;
			ObjectCache cache = MemoryCache.Default;
			if (cache.Contains(key))
			{
				result = (T)cache.Get(key);
			}

			return result;
		}

		public static void AddObjectToCache(string key, object obj)
		{
			AddObjectToCache(key, obj, 1.0);
		}

		public static void AddObjectToCache(string key, object obj, double absoluteExpiration)
		{
			ObjectCache cache = MemoryCache.Default;
			CacheItemPolicy cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(absoluteExpiration) };
			cache.Add(key, obj, cacheItemPolicy);
		}
	}
}
