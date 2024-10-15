using API.Application.Dto;
using API.Application.Interfaces.Repositories;
using API.Implementation.Validators;
using DataAccessModels;
using DataAccessModels.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Implementation.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        ProductInsertValidator _insertValidator;
        ProductUpdateValidator _updateValidator;
        public ProductRepository(TestDbContext context):base(context)
        {
            _insertValidator = new ProductInsertValidator(context);
            _updateValidator = new ProductUpdateValidator(context);
        }
        public PagedResponse<ProductWithCategories> SearchWithPagination(ProductSearch search)
        {
            var query = base.GetAll().AsQueryable();

            query = this.FilterData(query, search);

            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 8;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);
            int totalPages = totalCount > perPage ? (int)Math.Ceiling((double)totalCount / perPage) : 1;
            query = query.Skip(skip).Take(perPage);

            var response = new PagedResponse<ProductWithCategories>
            {
                Data = query.Select(x => new ProductWithCategories
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    Price = x.Price,
                    StockQuantity = x.StockQuantity,
                    CreatedAt = x.CreatedAt,
                    Categories = x.Categories.Select(c => new CategoryResponse
                    {
                        CategoryName = c.CategoryName,
                        CategoryId = c.CategoryId,
                        CreatedAt = c.CreatedAt
                    }).ToList()
                }),
                PerPage = perPage,
                CurrentPage = page,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
            return response;
        }
        private IQueryable<Product> FilterData(IQueryable<Product> query, ProductSearch search)
        {
            if (search.Id.HasValue)
                return query.Where(x => x.ProductId == search.Id.Value);
            if (search.Keyword != null)
                query = query.Where(product => product.ProductName.ToLower().Contains(search.Keyword.ToLower()) || product.Description.ToLower().Contains(search.Keyword.ToLower()));
            if (search.MinPrice.HasValue)
                query = query.Where(product => product.Price >= search.MinPrice.Value);
            if (search.MaxPrice.HasValue)
                query = query.Where(product => product.Price <= search.MaxPrice.Value);
            if (!search.CategoryIds.IsNullOrEmpty())
                query = query.Where(product => search.CategoryIds!.All(categoryId => product.Categories.Any(c => c.CategoryId == categoryId)));
            return query;
        }
        public void InsertNewProduct(ProductInsertData data)
        {
            //Configure debugger to not break when this exception is thrown.
            _insertValidator.ValidateAndThrow(data);

            Product p = new Product
            {
                ProductName = data.Name,
                Description = data.Description,
                Price = data.Price,
                StockQuantity = data.StockQuantity
            };
            p.Categories = BindProductCategories(data.CategoryIds);
            base.Add(p);
        }
        private List<Category> BindProductCategories(List<int> categoryIds)
        {
            return _context.Categories.Where(x => categoryIds.Contains(x.CategoryId)).ToList();
        }
        public void UpdateProduct(ProductUpdateData data)
        {
            //Configure debugger to not break when this exception is thrown.
            _updateValidator.ValidateAndThrow(data);

            Product p = _context.Products.Where(x=>x.ProductId == data.Id).Include(x=>x.Categories).First();
            p.ProductName = data.Name;
            p.Price = data.Price;
            p.Description = data.Description;
            List<Category> categories = BindProductCategories(data.CategoryIds);
            foreach (Category cat in categories) {
                if (!p.Categories.Any(c => c.CategoryId == cat.CategoryId))
                {
                    p.Categories.Add(cat);
                }
            }
            p.StockQuantity = data.StockQuantity;
            base.Update(p);
        }
    }
}
