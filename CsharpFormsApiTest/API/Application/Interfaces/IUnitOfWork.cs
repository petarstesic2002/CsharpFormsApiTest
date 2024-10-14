using API.Application.Interfaces.Repositories;
using API.Implementation.Repositories;

namespace API.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ProductRepository ProductRepository { get; }
        CategoryRepository CategoryRepository { get; }
        int Save();
    }
}
