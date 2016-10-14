using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IDevolucaoService : IServiceBase<Devolucao>
    {
        IEnumerable<Devolucao> ObtemDevolucoesOrdenado();

        IEnumerable<Devolucao> ObtemDevolucoesPorFiltroOrdenado(Devolucao pDevolucao);

        IEnumerable<Devolucao> ObtemDevolucoesPorFiltro(Devolucao pDevolucao);
        void GravarDevolucao(Devolucao lDevolucao);
    }
}
