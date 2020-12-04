namespace Shared.Pagination.Models
{
    public class GenericParameters
    {
        private int _pageSize;
        private int _maxPageSize;

        public GenericParameters()
        {
            _pageSize = 10;
            _maxPageSize = 50;
            PageNumber = 1;
        }

        public int PageNumber { get; set; }

        public int PageSize
        {
            get
            {
                return _pageSize > _maxPageSize ? _maxPageSize : _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}
