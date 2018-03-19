using CRMProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CRMProject.Repository
{
    public abstract class AbstractRepository<T> where T : class
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

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
    }
}