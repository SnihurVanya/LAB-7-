using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public delegate TResult Func<TKey, TResult>(TKey key);
    public class FunctionCache<TKey, TResult>
    {
        private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
        private TimeSpan cacheDuration;

        public FunctionCache(TimeSpan cacheDuration)
        {
            this.cacheDuration = cacheDuration;
        }

        public TResult GetOrAdd(TKey key, Func<TKey, TResult> function)
        {
            if (cache.TryGetValue(key, out CacheItem item) && !item.IsExpired)
            {
                return item.Value;
            }

            TResult result = function(key);
            cache[key] = new CacheItem(result, DateTime.Now.Add(cacheDuration));
            return result;
        }

        private class CacheItem
        {
            public TResult Value { get; }
            public DateTime Expiration { get; }

            public bool IsExpired => DateTime.Now >= Expiration;

            public CacheItem(TResult value, DateTime expiration)
            {
                Value = value;
                Expiration = expiration;
            }
        }
    }
}
