using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IDevolucaoRepository : IRepositoryBase<Devolucao>
    {
        IEnumerable<Devolucao> ObtemDevolucoesPorFiltro(Devolucao pDevolucao);
        void GravarDevolucao(Devolucao lDevolucao);
    }
}
