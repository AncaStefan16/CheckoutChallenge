using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PaymentGateway.Entities.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        IEnumerable<T> List();
    }
}
