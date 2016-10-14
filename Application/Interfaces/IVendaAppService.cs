using Domain.Entities;
using PagedList;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IVendaAppService : IAppServiceBase<Venda>
    {
        IEnumerable<Venda> ObtemVendasOrdenado();

        void GravarVenda(Venda lVenda);
        IEnumerable<Venda> ObtemPorFiltro(Venda lVenda);
    }
}
