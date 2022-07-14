using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Aspect.Caching.Concrete
{
   public class McCacheManager : ICacheManager
    {
        private readonly IMemoryCache cache;

        public McCacheManager(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public void add(string key, object value, int duration)
        {
            cache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return cache.Get<T>(key);

        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public bool IsAdd(string key)
        {
          return  cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void ReoveByPattern(string pattern)
        {
            var cacheExtriesCollectionDefination = typeof(MemoryCache).GetProperty("EntriesCollection"
                , System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var cacheExtriesCollection = cacheExtriesCollectionDefination.GetValue(cache) as dynamic;

            List<ICacheEntry> cacheEntries = new List<ICacheEntry>();

            foreach (var cacheitem in cacheExtriesCollection)
            {
                ICacheEntry entry = cacheitem.GetType().GetProperty("Value").GetValue(cacheitem, null);

                cacheEntries.Add(entry);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keyToRemove = cacheEntries.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keyToRemove)
            {
                cache.Remove(key);
            }
        }
    }
}
