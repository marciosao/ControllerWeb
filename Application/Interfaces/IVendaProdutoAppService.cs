using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IVendaProdutoAppService : IAppServiceBase<VendasProduto>
    {
        IEnumerable<VendasProduto> ObtemPorFiltro(VendasProduto lVendasProduto);
    }
}
