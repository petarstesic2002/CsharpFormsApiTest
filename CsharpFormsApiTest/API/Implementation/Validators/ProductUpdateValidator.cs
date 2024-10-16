﻿using API.Application.Dto;
using DataAccessModels;
using FluentValidation;
using System.Reflection.Metadata.Ecma335;

namespace API.Implementation.Validators
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateData>
    {
        private readonly TestDbContext _context;
        public ProductUpdateValidator(TestDbContext context)
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
                                .Must((x, y) => CheckProductName(x.Name, x.Id))
                                .WithMessage("Name must be unique.");

            RuleFor(x => x.CategoryIds).NotEmpty()
                                       .WithMessage("Product must have at least one category.")
                                       .Must(CheckCategoryIds)
                                       .WithMessage("Invalid categories.");

            RuleFor(x => x.StockQuantity).NotEmpty()
                                         .GreaterThan(0)
                                         .WithMessage("Quantity is required and must be greater than 0");

            RuleFor(x => x.Id).NotEmpty()
                              .Must(CheckId)
                              .WithMessage("Invalid Id");
        }
        private bool CheckId(int id)
        {
            if (!_context.Products.Any(x => x.ProductId == id))
                return false;
            return true;
        }
        private bool CheckProductName(string name, int id)
        {
            if (_context.Products.Any(x => x.ProductName.ToLower() == name.ToLower() && x.ProductId != id))
                return false;
            return true;
        }
        public bool CheckCategoryIds(List<int> ids)
        {
            if (!_context.Categories.Any(x => ids.Contains(x.CategoryId)))
                return false;
            return true;
        }
    }
}
