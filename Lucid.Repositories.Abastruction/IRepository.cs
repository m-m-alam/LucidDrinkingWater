
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Lucid.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        T GetById(int id);
        T GetById(int id, Expression<Func<T, object>> include);
        bool IsExists(Expression<Func<T, bool>> predicate);
        //IList<T> GetAll(Expression<Func<T, object>> include);
        IList<T> GetAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> include=null);
    }
}
