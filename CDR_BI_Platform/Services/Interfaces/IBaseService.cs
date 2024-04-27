using System.Collections.Generic;
using CDR_BI_Platform.Models;

namespace CDR_BI_Platform.Services.Interfaces
{
    public interface IBaseService<TEntity>
        where TEntity : class, IEntityDb
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        int Create(TEntity create);
        void Update(TEntity edit);
        void Delete(int id);
    }
}
