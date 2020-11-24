using Domain.Entities;
using Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DocumentRepository<T> : GenericRepository<T> where T : Document
    {
        public DocumentRepository()
        {
        }

        public override IList<T> GetAll()
        {
            return _context
                .Entities
                .Include(p => p.DocumentType)
                .Where(p => p.DocumentTypeId == p.DocumentType.Id)
                .ToList<T>();
        }

        public override T SearchById(long id)
        {
            return _context
                .Entities
                .Include(p => p.DocumentType)
                .Where(p => p.DocumentTypeId == p.DocumentType.Id &&  p.Id == id)
                .SingleOrDefault<T>();
        }
    }
}
