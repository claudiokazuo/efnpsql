using Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Domain.Queries
{
    public static class EntityQuery<T> where T: Entity
    {        
        public static Expression<Func<T, bool>> GetById(long id)
        {
            return entity => entity.Id == id;
        }

        public static Expression<Func<T, bool>> GetByIsActive(bool isActive)
        {
            return entity => entity.IsActive == isActive;
        }

        public static Expression<Func<T, bool>> GetByCreatedOn(DateTime createdOn)
        {
            return entity =>
                entity.CreatedOn.Year == createdOn.Year &&
                entity.CreatedOn.Month == createdOn.Month &&
                entity.CreatedOn.Day == createdOn.Day;
        }
        
        public static Expression<Func<T, bool>> GetByUpdateOn(DateTime updateOn)
        {
            return entity =>
                entity.UpdatedOn.Year == updateOn.Year &&
                entity.UpdatedOn.Month == updateOn.Month &&
                entity.UpdatedOn.Day == updateOn.Day;
        }
    }
}
