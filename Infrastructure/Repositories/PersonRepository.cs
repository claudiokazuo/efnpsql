using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PersonRepository<T> : GenericRepository<T> where T : Person
    {
        public PersonRepository(GenericContext context) : base(context)
        {
            _query = _entities
                .Include(p => p.Documents)
                .ThenInclude(p => p.DocumentType);
        }       
    }
}
