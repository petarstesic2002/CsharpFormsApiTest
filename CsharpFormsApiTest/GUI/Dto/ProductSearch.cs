using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Dto
{
    public class ProductSearch : PagedSearch
    {
        public int? Id { get; set; }
        public string? Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}
