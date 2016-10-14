using Domain.Entities;
using PagedList;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IVendaService : IServiceBase<Venda>
    {
        IEnumerable<Venda> ObtemVendasOrdenado();

        void GravarVenda(Venda lVenda);
        IEnumerable<Venda> ObtemPorFiltro(Venda lVenda);
    }
}
