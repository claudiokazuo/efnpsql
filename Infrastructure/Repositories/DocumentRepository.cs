using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DocumentRepository<T> : GenericRepository<T> where T : Document
    {
        public DocumentRepository(GenericContext context) : base(context)
        {
            _query = _entities.Include(p => p.DocumentType);
        }
    }
}
