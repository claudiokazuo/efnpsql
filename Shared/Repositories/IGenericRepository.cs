using Shared.Entities;
using Shared.Pagination.Contracts;
using Shared.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        Task<IPagedList<T>> GetAllAsync(GenericParameters parameters);
        T SearchById(long id);
        T SearchEntity(Expression<Func<T, bool>> expression);
        IEnumerable<T> SearchEntities(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
