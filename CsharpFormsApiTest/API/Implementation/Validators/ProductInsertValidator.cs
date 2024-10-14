using API.Application.Dto;
using DataAccessModels;
using FluentValidation;

namespace API.Implementation.Validators
{
    public class ProductInsertValidator : AbstractValidator<ProductInsertData>
    {
        private readonly TestDbContext _context;
        public ProductInsertValidator(TestDbContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Description).NotEmpty()
                                       .WithMessage("Description is required.");

            RuleFor(x => x.Price).NotEmpty()
                                 .GreaterThan(0)
                                 .WithMessage("Price is required and must be greater than 0.");

            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required.")
                                .Must(CheckProductName)
                                .WithMessage("Name must be unique.");

            RuleFor(x => x.CategoryIds).NotEmpty()
                                       .WithMessage("Product must have at least one category.")
                                       .Must(CheckCategoryIds)
                                       .WithMessage("Invalid categories.");

            RuleFor(x => x.StockQuantity).NotEmpty()
                                         .GreaterThan(0)
                                         .WithMessage("Quantity is required and must be greater than 0");
        }
        private bool CheckProductName(string name)
        {
            if (_context.Products.Where(x=>x.ProductName.Equals(name,StringComparison.OrdinalIgnoreCase)).Any())
                return false;
            return true;
        }
        public bool CheckCategoryIds(List<int> ids)
        {
            if (!_context.Categories.Any(x=>ids.Contains(x.CategoryId)))
                return false;
            return true;
        }
    }
}
