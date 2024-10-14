using DataAccessModels.Entities;

namespace API.Application.Dto
{
    public class ProductWithCategories
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description {  get; set; } = null!;
        public decimal Price {  get; set; }
        public int StockQuantity {  get; set; }
        public List<CategoryResponse> Categories {  get; set; } = null!;
        public DateTime CreatedAt {  get; set; }
    }
}
