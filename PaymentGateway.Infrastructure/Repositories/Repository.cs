using PaymentGateway.Entities;
using PaymentGateway.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PaymentGateway.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext dbContext;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }        

        public IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> List()
        {
            return dbContext.Set<T>().ToList();
        }
    }
}
