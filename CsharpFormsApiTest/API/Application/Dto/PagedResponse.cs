namespace API.Application.Dto
{
    public class PagedResponse<T> where T : class
    {
        public IEnumerable<T> Data { get; set; } = null!;
        public int CurrentPage { get; set; }
        public int TotalCount{ get; set; }
        public int TotalPages {  get; set; }
        public int PerPage { get; set; } = 8;
    }
}
