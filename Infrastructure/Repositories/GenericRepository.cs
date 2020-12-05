using Domain.Queries;
using Infrastructure.Contexts;
using Infrastructure.Pagination.PagedLists;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Pagination.Contracts;
using Shared.Pagination.Models;
using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                .Where(GenericEntityQuery<T>.GetById(id))
                .SingleOrDefault();
        }

        public IEnumerable<T> SearchEntities(Expression<Func<T, bool>> expression)
        {
            return _query.Where(expression);
        }

        public T SearchEntity(Expression<Func<T, bool>> expression)
        {
            return _query.Where(expression).SingleOrDefault();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
