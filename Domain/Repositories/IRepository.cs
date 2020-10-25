using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IList<T> GetAll();
        T SearchById(long id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
