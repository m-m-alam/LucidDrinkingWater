using Lucid.Repositories.Abstractions;
using Lucid.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual IList<T> GetAll()
        {
            return _repository.GetAll();
        }

       
        public IList<T> GetAll(Expression<Func<T, bool>> filter=null, Expression<Func<T, object>> include=null)
        {
            return _repository.GetAll(filter, include);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T GetById(int id, Expression<Func<T, object>> include)
        {
            return _repository.GetById(id, include);
        }

        public bool IsExists(Expression<Func<T, bool>> predicate)
        {
            return _repository.IsExists(predicate);
        }

        public virtual void Update(T entity)
        {            
            _repository.Update(entity);
        }
    }
}
