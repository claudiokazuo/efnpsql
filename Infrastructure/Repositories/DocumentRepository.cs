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
        public DocumentRepository(GenericContext context) : base(context)
        {
        }

        public override IEnumerable<T> GetAll()
        {
            return _entities
                .Include(p => p.DocumentType)
                .AsEnumerable<T>();
        }

        public override T SearchById(long id)
        {
            return _entities
                .Include(p => p.DocumentType)                
                .SingleOrDefault<T>(EntityQuery<T>.GetById(id));
        }
    }
}
