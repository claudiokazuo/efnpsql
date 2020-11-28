using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Pagination.PagedLists
{
    public interface IPagedList<T> where T : Entity
    {
        IEnumerable<T> Items { get; }
        Metadata Pagination { get; }
    }
}
