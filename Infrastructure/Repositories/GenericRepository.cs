using Domain.Entities;
using Domain.Pagination.PagedLists;
using Domain.Pagination.Queries;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Pagination.PagedLists;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected GenericContext _context;
        protected DbSet<T> _entities;
        protected IQueryable<T> _query;
        public GenericRepository(GenericContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
            _query = _entities;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _query.AsEnumerable();
        }

        public async Task<IPagedList<T>> GetAllAsync(GenericParameters parameters)
        {
            return await GenericPagedList<T>.ToPagedList(
                _query, 
                parameters.PageNumber, 
                parameters.PageSize);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual T SearchById(long id)
        {
            return _entities
                .Where(EntityQuery<T>.GetById(id))
                .SingleOrDefault();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
