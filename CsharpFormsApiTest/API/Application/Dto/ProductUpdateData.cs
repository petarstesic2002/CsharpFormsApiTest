namespace API.Application.Dto
{
    public class ProductUpdateData
    {
        public int Id { get; set; }
        public string Name {  get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price {  get; set; }
        public List<int> CategoryIds {  get; set; } = null!;
        public int StockQuantity {  get; set; }
    }
}
