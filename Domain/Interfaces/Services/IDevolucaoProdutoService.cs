using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IDevolucaoProdutoService : IServiceBase<DevolucaoProduto>
    {
        IEnumerable<DevolucaoProduto> ObtemPorFiltro(Devolucao pDevolucao);
    }
}
