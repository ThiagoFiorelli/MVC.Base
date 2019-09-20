

using System.Collections.Generic;


namespace BaseDDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(bool AsNoTracking = false);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
