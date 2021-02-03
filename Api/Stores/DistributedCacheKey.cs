using Shared.Stores;

namespace Api.Stores
{
    public class DistributedCacheKey<T> : ICacheKey<T> where T : class
    {
        private readonly long _id;

        public DistributedCacheKey(long id)
        {
            _id = id;
        }

        public string CacheKey
        {
            get => $"{typeof(T)}:{_id}";
        }
    }
}
