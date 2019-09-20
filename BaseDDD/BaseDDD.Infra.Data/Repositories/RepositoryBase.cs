

using BaseDDD.Domain.Interfaces;
using BaseDDD.Domain.Interfaces.Repositories;
using BaseDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BaseDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected BaseDDDContext Db = new BaseDDDContext();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get All with NoTrancking or Not
        /// NoTracking = ture for exhibition purpose
        /// </summary>
        /// <param name="AsNoTracking"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(bool AsNoTracking = false)
        {
            return AsNoTracking ? Db.Set<TEntity>().AsNoTracking().ToList() : Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
