using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class VendaProdutoService : ServiceBase<VendasProduto>, IVendaProdutoService
    {
        private readonly IVendaProdutoRepository _vendaProdutoRepository;

        public VendaProdutoService(IVendaProdutoRepository vendaProdutoRepository) : base(vendaProdutoRepository)
        {
            _vendaProdutoRepository = vendaProdutoRepository;
        }

        public IEnumerable<VendasProduto> ObtemPorFiltro(VendasProduto lVendasProduto)
        {
            return _vendaProdutoRepository.ObtemPorFiltro(lVendasProduto);
        }
    }
}
