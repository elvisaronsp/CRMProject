using CRMProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CRMProject.Repository
{
   
    public interface IAbstractRepositoryBuilder<T>
    {
        IAbstractRepositoryBuilder<T> Include<K>(Expression<Func<T, K>> expression);
        IAbstractRepositoryBuilder<T> Where(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Fetch();
    }

    public abstract class AbstractRepository<T> : IAbstractRepositoryBuilder<T> where T : class
    {
        public virtual void Create(T entity)

        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
        

        public virtual void Update(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {

                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private ApplicationDbContext _currentContext;
        private IQueryable<T> _currentQueryable;

        

        public IAbstractRepositoryBuilder<T> Get()
        {
            _currentContext = new ApplicationDbContext();
            _currentQueryable = _currentContext.Set<T>();
            return this;
        }

        public IAbstractRepositoryBuilder<T> Include<K>(Expression<Func<T, K>> expression)
        {
            _currentQueryable = _currentQueryable.Include(expression);
            return this;
        }

        public IAbstractRepositoryBuilder<T> Where(Expression<Func<T, bool>> predicate)
        {
            _currentQueryable = _currentQueryable.Where(predicate);
            return this;
        }

        public IEnumerable<T> Fetch()
        {
            var result = _currentQueryable.ToList();
            _currentContext.Dispose();
            return result;

        }

    }
}