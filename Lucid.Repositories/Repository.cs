using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;
        public Repository(DbContext context) 
        { 
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public virtual IList<T> GetAll()
        {
            return _dbSet.ToList();
            
        }
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }
      
    }
}
