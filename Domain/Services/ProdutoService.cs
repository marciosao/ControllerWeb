using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>,IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> ObterPorFiltro(Produto pProduto)
        {
            return _produtoRepository.ObterPorFiltro(pProduto);
        }

        public IEnumerable<Produto> ObterProdutosEstoqueZerado()
        {
            return _produtoRepository.ObterProdutosEstoqueZerado();
        }

        public Produto Salvar(Produto pProduto)
        {
            return _produtoRepository.Salvar(pProduto);
        }

        public IEnumerable<Produto> ObtemPorFiltro(string pCodigo, string pNome, int pIdFabricante, int pIdModelo, int pFiltroQtdEstoque)
        {
            return _produtoRepository.ObtemPorFiltro(pCodigo, pNome, pIdFabricante, pIdModelo, pFiltroQtdEstoque);
        }
    }
}
