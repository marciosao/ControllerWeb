using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaProdutoRepository : IRepositoryBase<VendasProduto>
    {
        IEnumerable<VendasProduto> ObtemPorFiltro(VendasProduto pVendasProduto);
    }
}
