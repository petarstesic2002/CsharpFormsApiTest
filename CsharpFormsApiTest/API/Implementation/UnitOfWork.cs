using API.Application.Interfaces;
using API.Application.Interfaces.Repositories;
using API.Implementation.Repositories;
using DataAccessModels;

namespace API.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext _context;
        public UnitOfWork(TestDbContext context)
        {
            _context = context;
        }

        public ProductRepository ProductRepository => new ProductRepository(_context);
        public CategoryRepository CategoryRepository => new CategoryRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
