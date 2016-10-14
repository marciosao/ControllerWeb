using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IRepositoryBase<Venda>
    {
        void GravarVenda(Venda lVenda);

        IEnumerable<Venda> ObterPorFiltro(Venda pVenda);
    }
}
