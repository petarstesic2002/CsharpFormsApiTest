using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI.Dto
{
    public class PagedDto<T> where T : class
    {
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; } = null!;

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("perPage")]
        public int PerPage { get; set; }
    }
}
