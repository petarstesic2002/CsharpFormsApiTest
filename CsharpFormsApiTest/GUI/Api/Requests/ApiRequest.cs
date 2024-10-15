using GUI.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public PagedDto<ProductDto> GetProducts(ProductSearch search)
        {
            RestRequest request = new RestRequest(_baseUrl + "products");
            request.Method = Method.Get;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(search);
            var response = Api.Client.Execute<PagedDto<ProductDto>>(request);
            return response.Data!;
        }
        public List<CategoryDto> GetCategories()
        {
            return Api.Client.Get<List<CategoryDto>>(_baseUrl + "categories")!;
        }
        public RestResponse AddProduct(AddProduct dto)
        {
            RestRequest request = new RestRequest(_baseUrl + "products");
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(dto);
            return Api.Client.Execute(request);
        }
        public RestResponse DeleteProduct(int id)
        {
            RestRequest request = new RestRequest(_baseUrl + "products");
            request.Method = Method.Delete;
            request.AddBody(id);
            return Api.Client.Execute(request);
        }
        public RestResponse UpdateProduct(UpdateProduct dto)
        {
            RestRequest request = new RestRequest(_baseUrl + "products");
            request.Method = Method.Put;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(dto);
            return Api.Client.Execute(request);
        }
    }
}
