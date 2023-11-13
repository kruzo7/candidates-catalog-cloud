namespace StaticWebApp.CVGatorBetaBlazorWasm.Commons
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;        
        public PaginatedList(List<T> elements)
        {
            base.AddRange(elements);
        }
    }
}
