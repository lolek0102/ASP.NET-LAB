namespace Labolatorium_3_8.Services
{
    public class PagingList<T>
    {
        public IEnumerable<T> Items { get; private set; }
        public int TotalCount { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public PagingList(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}