using CRMProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CRMProject.Interfaces

{
    public interface IAbstractRepository<T> where T : class
    {
        IAbstractRepositoryBuilder<T> Get();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}