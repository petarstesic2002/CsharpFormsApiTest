using API.Application.Dto;

namespace API.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryResponse> GetCategories();
    }
}
