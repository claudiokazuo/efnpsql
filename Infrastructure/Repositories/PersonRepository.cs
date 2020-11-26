using Domain.Entities;
using Domain.Queries;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PersonRepository<T> : GenericRepository<T> where T : Person
    {
        public PersonRepository(GenericContext context) : base(context)
        {
        }

        public override IEnumerable<T> GetAll()
        {
            return _entities
                .Include(p => p.Documents)
                .ThenInclude(p => p.DocumentType)
                .AsEnumerable<T>();
        }

        public override T SearchById(long id)
        {
            return _entities
                .Include(p => p.Documents)
                .ThenInclude(p => p.DocumentType)
                .Where(EntityQuery<T>.GetById(id))
                .SingleOrDefault<T>();
        }
    }
}
