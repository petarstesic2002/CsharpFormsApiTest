namespace API.Application.Dto
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedAt {  get; set; }
    }
}
