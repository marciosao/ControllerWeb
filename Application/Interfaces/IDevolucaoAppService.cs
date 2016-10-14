using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDevolucaoAppService : IAppServiceBase<Devolucao>
    {
        IEnumerable<Devolucao> ObtemDevolucoesOrdenado();

        IEnumerable<Devolucao> ObtemDevolucoesPorFiltroOrdenado(Devolucao pDevolucao);
        void GravarDevolucao(Devolucao lDevolucao);
    }
}
