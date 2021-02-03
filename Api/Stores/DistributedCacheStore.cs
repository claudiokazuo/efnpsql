using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Shared.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Stores
{
    public class DistributedCacheStore<T> : ICacheStore<T> where T : class
    {
        private readonly IDistributedCache _distributedCache;
        private int _slidingExpiration;
        private int _absoluteExpiration;

        public DistributedCacheStore(IDistributedCache distributedCache, int slidingExpiration, int absoluteExpiration)
        {
            _distributedCache = distributedCache;
            _slidingExpiration = slidingExpiration;
            _absoluteExpiration = absoluteExpiration;
        }

        public async Task AddDataAsync(T data, string key)
        {
            var serializedData = JsonConvert.SerializeObject(data);
            var encodedData = Encoding.UTF8.GetBytes(serializedData);

            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(_slidingExpiration))
                .SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(_absoluteExpiration));

            await _distributedCache.SetAsync(key, encodedData, options).ConfigureAwait(true);
        }

        public async Task AddDataListAsync(IEnumerable<T> data, string key)
        {
            var serializedData = JsonConvert.SerializeObject(data);
            var encodedData = Encoding.UTF8.GetBytes(serializedData);

            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(_slidingExpiration))
                .SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(_absoluteExpiration));

            await _distributedCache.SetAsync(key, encodedData, options).ConfigureAwait(true);
        }

        public async Task<T> GetDataAsync(string key)
        {
            var encodedData = await _distributedCache.GetAsync(key).ConfigureAwait(true);          
            if (encodedData == null)
            {
                return null; 
            }
            var serializedData = Encoding.UTF8.GetString(encodedData);
            return JsonConvert.DeserializeObject<T>(serializedData);

        }

        public async Task<IEnumerable<T>> GetDataListAsync(string key)
        {
            var encodedData = await _distributedCache.GetAsync(key).ConfigureAwait(true);
            if (encodedData == null)
            {
                return null;
            }
            var serializedData = Encoding.UTF8.GetString(encodedData);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(serializedData);
        }
    }
}
