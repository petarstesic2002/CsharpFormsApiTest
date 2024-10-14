namespace API.Application.Dto
{
    public class ProductSearch : PagedSearch
    {
        public int? Id { get; set; }
        public string? Keyword {  get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice {  get; set; }
        public IEnumerable<int>? CategoryIds { get; set; }
    }
}
