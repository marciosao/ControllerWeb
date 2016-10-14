using System;
using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Infra.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Infra.Data.Repositories
{
    public class RepositoryBase<TEntity>: IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected bdComcalContext Db = new bdComcalContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity ObtemPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity AddWithReturn(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();

            return obj;
        }
    }
}
