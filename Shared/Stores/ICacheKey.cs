namespace Shared.Stores
{
    public interface ICacheKey<T> where T: class
    {
        string CacheKey { get; }
    }
}
