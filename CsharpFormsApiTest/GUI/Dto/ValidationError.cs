using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI.Dto
{
    public class ValidationError
    {
        [JsonPropertyName("propertyName")]
        public string PropertyName { get; set; } = null!;
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; } = null!; 
    }
}
