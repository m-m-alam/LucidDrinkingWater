using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lucid.Repositories.Abstractions;

namespace Lucid.Services.Abstractions
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        T GetById(int id);
        T GetById(int id, Expression<Func<T, object>> include);
        bool IsExists(Expression<Func<T, bool>> predicate);
        IList<T> GetAll(Expression<Func<T, bool>> filter=null, Expression<Func<T, object>> include=null);
    }
}
