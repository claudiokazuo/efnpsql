using Domain.Entities;
using Domain.Queries;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DocumentRepository<T> : GenericRepository<T> where T : Document
    {
        public DocumentRepository(GenericContext<T> context) : base(context)
        {
        }

        public override IList<T> GetAll()
        {
            return _context
                .Entities
                .Include(p => p.DocumentType)
                .Include(p => p.Person)
                .ToList<T>();
        }

        public override T SearchById(long id)
        {
            return _context
                .Entities
                .Include(p => p.DocumentType)
                .Include(p => p.Person)
                .Where(EntityQuery<T>.GetById(id))
                .SingleOrDefault<T>();
        }
    }
}
