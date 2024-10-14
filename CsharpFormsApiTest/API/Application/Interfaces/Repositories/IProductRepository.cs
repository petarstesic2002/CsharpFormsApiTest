using API.Application.Dto;
using DataAccessModels.Entities;

namespace API.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        PagedResponse<ProductWithCategories> SearchWithPagination(ProductSearch search);
        void InsertNewProduct(ProductInsertData data);
    }
}
