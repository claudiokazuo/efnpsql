using Shared.Entities;
using Shared.Pagination.Models;
using System.Collections.Generic;

namespace Shared.Pagination.Contracts
{
    public interface IPagedList<T> where T : Entity
    {
        IEnumerable<T> Items { get; }
        MetaData Pagination { get; }
    }
}
