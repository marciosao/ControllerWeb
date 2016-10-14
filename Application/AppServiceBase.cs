using Application.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using PagedList;

namespace Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity ObtemPorId(int id)
        {
            return _serviceBase.ObtemPorId(id);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return _serviceBase.ObtemTodos();
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public PagedList<TEntity> ObtemTodosPorPagina(int pageNumber, int pageSize)
        {
            var lEntidade = _serviceBase.ObtemTodos();

            return (PagedList<TEntity>)lEntidade.ToPagedList(pageNumber, pageSize);
        }
    }
}
