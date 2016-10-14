using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IDevolucaoProdutoRepository : IRepositoryBase<DevolucaoProduto>
    {
        IEnumerable<DevolucaoProduto> ObtemPorFiltro(Devolucao pDevolucao);
    }
}
