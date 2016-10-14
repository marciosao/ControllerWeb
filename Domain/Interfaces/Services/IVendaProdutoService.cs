using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IVendaProdutoService : IServiceBase<VendasProduto>
    {
        IEnumerable<VendasProduto> ObtemPorFiltro(VendasProduto lVendasProduto);
    }
}
