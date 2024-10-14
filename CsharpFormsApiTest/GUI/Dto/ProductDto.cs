using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public List<CategoryDto> Categories { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
