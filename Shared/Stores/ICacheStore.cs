using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Stores
{
    public interface ICacheStore<T> 
    {
        Task AddDataAsync(T data, string key);
        Task AddDataListAsync(IEnumerable<T> data, string key);
        Task<T> GetDataAsync(string key);
        Task<IEnumerable<T>> GetDataListAsync(string key);
    }
}
