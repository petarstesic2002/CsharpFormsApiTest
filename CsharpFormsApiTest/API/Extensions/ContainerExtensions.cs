using API.Application.Interfaces;
using API.Application.Interfaces.Repositories;
using API.Implementation;
using API.Implementation.ErrorLogging;
using API.Implementation.Repositories;
using API.Implementation.Validators;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddLogger(this IServiceCollection services)
        {
            services.AddTransient<IErrorLogger, ConsoleErrorLogger>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<ProductInsertValidator>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
        public static void AddContext(this IServiceCollection services)
        {
            services.AddTransient(x => new TestDbContext());
        }
    }
}
