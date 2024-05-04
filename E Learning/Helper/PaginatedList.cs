using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Helper
{
    public class PaginatedList<T>
    {
        public IReadOnlyList<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IReadOnlyList<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);

        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;
        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItems);

        public static  PaginatedList<T> CreateAsync(IReadOnlyList<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count; //total number of items in the source data.      
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);

        }
    }
}
