using Domain.Entities;
using Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Repositories
{
    public class PersonRepository<T> : GenericRepository<T> where T : Person
    {
        public PersonRepository()
        {
        }

        public override IList<T> GetAll()
        {
            return _context
                .Entities
                .Include(p => p.Documents)
                .ThenInclude(p => p.DocumentType)                
                .ToList<T>();
        }

        public override T SearchById(long id)
        {
            return _context
                .Entities
                .Include(p => p.Documents)
                .ThenInclude(p => p.DocumentType)
                .Where(EntityQuery<T>.GetById(id))
                .SingleOrDefault<T>();
        }
    }
}
