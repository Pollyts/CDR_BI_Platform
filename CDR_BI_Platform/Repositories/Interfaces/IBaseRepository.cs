using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using CDR_BI_Platform.Models;
using System.Threading.Tasks;

namespace CDR_BI_Platform.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class, IEntityDb
    {
        IQueryable<TEntity> GetQuery();

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        Task SaveChanges();
    }
}
