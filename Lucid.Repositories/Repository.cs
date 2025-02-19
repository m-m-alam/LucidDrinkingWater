using Lucid.Models;
using Lucid.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

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
        
        
        public virtual IList<T> GetAll(Expression<Func<T, bool>> filter,Expression<Func<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            if (include != null)            {
                
                    query = query.Include(include);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public virtual IList<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetById(int id, Expression<Func<T, object>> include)
        {
            IQueryable<T> query = _dbSet;

            // Apply includes dynamically
            if (include!=null)
            {
                query = query.Include(include);
            }
            
            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }


        public virtual bool IsExists(Expression<Func<T, bool>> predicate)
        {
            var query = _dbSet.AsQueryable();

            return query.Any(predicate);
        }
    }
}
