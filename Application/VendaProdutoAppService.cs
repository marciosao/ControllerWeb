using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System.Collections.Generic;

namespace Application
{
    public class VendaProdutoAppService : AppServiceBase<VendasProduto>, IVendaProdutoAppService
    {
        private readonly IVendaProdutoService _vendaProdutoService;

        public VendaProdutoAppService(IVendaProdutoService vendaProdutoService) : base(vendaProdutoService)
        {
            _vendaProdutoService = vendaProdutoService;

        }

        public IEnumerable<VendasProduto> ObtemPorFiltro(VendasProduto lVendasProduto)
        {
            return _vendaProdutoService.ObtemPorFiltro(lVendasProduto);
        }
    }
}
