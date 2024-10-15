using API.Application.Dto;
using API.Application.Interfaces.Repositories;
using DataAccessModels;
using Microsoft.EntityFrameworkCore;

namespace API.Implementation.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly TestDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TestDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
        public T GetById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                throw new NullReferenceException("Entity does not exist");
            return entity;
        }
        public void Remove(int id)
        {
            var entity = this.GetById(id);
            _dbSet.Remove(entity);
        }
        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
