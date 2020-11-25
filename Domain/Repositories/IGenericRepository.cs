using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T SearchById(long id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
