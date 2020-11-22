using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected GenericContext<T> _context;

        public GenericRepository()
        {
            _context = new GenericContext<T>();
        }

        public void Add(T entity)
        {
            _context.Entities.Add(entity);
            _context.SaveChanges();
        }

        public virtual IList<T> GetAll()
        {
            return _context.Entities.ToList();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public virtual T SearchById(long id)
        {
            return _context
                .Entities
                .Where(EntityQuery<T>.GetById(id))
                .SingleOrDefault();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
