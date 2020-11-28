using System;

namespace Domain.Pagination.PagedLists
{
    public class Metadata
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious { get; private set; }
        public bool HasNext { get; private set; }

        public Metadata(int currentPage, int pageSize, int totalCount)
        {            
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPrevious = currentPage > 1;
            HasNext = currentPage < TotalPages;
        }
    }
}
