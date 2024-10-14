namespace API.Application.Dto
{
    public class ProductInsertData
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity {  get; set; }
        public List<int> CategoryIds { get; set; } = null!;
    }
}
