using GUI.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI.Api.Requests
{
    public class ApiRequest
    {
        private string _baseUrl = "http://localhost:5094/api/";
        public ApiRequest(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public ApiRequest() { }
        public PagedDto<ProductDto> getProducts(ProductSearch search)
        {
            PagedDto<ProductDto> response = Api.Client.Get<PagedDto<ProductDto>>(_baseUrl + "products", search)!;
            return response;
        }
        public List<CategoryDto> getCategories()
        {
            return Api.Client.Get<List<CategoryDto>>(_baseUrl + "categories")!;
        }
    }
}
