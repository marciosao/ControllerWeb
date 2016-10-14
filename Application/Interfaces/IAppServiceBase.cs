using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity:class
    {
        void Add(TEntity obj);

        TEntity ObtemPorId(int id);

        IEnumerable<TEntity> ObtemTodos();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
