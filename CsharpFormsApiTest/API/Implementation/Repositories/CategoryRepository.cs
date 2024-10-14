using API.Application.Dto;
using API.Application.Interfaces.Repositories;
using DataAccessModels;
using DataAccessModels.Entities;

namespace API.Implementation.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TestDbContext context):base(context)
        {
            
        }
        public List<CategoryResponse> getCategories()
        {
            return base.GetAll().Select(x => new CategoryResponse
            {
                CategoryName = x.CategoryName,
                CategoryId = x.CategoryId,
                CreatedAt = x.CreatedAt
            }).ToList();
        }
    }
}
