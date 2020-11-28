using Domain.Entities;
using Domain.Pagination.PagedLists;
using Domain.Pagination.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        Task<IPagedList<T>> GetAllAsync(GenericParameters parameters);
        T SearchById(long id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);        
    }
}
