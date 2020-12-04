using Newtonsoft.Json;
using System;

namespace Shared.Pagination.Models
{
    public class MetaData
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious { get; private set; }
        public bool HasNext { get; private set; }

        public MetaData(int currentPage, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPrevious = currentPage > 1;
            HasNext = currentPage < TotalPages;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
