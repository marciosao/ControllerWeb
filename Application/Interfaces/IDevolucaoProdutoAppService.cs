using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDevolucaoProdutoAppService : IAppServiceBase<DevolucaoProduto>
    {
        IEnumerable<DevolucaoProduto> ObtemPorFiltro(Devolucao pDevolucao);
    }
}
