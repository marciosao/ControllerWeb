using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Application
{
    public class ProdutoAppService : AppServiceBase<Produto>,IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService) : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public Produto Salvar(Produto pProduto)
        {
            return _produtoService.Salvar(pProduto);
        }

        public IEnumerable<Produto> ObtemPorFiltro(Produto pProduto)
        {
            var lProdutos = _produtoService.ObterPorFiltro(pProduto);

            return lProdutos;
        }
        ////////public PagedList<Produto> ObtemPorFiltro(Produto pProduto, int pageNumber, int pageSize)
        ////////{
        ////////    var lProdutos = _produtoService.ObterPorFiltro(pProduto);

        ////////    return (PagedList<Produto>)lProdutos.ToPagedList(pageNumber, pageSize);
        ////////}

        public PagedList<Produto> ObtemPorFiltroQuantidadeDisponivel(int pageNumber, int pageSize)
        {
            var lProdutos = _produtoService.ObtemTodos();

            lProdutos = lProdutos.Where(x => x.QtdEstoque > 0).ToList();

            return (PagedList<Produto>)lProdutos.ToPagedList(pageNumber, pageSize);
        }

        public PagedList<Produto> ObtemPorFiltroQuantidadeDisponivel(Produto pProduto, int pageNumber, int pageSize)
        {
            var lProdutos = _produtoService.ObterPorFiltro(pProduto);

            lProdutos = lProdutos.Where(x => x.QtdEstoque > 0).ToList();

            return (PagedList<Produto>)lProdutos.ToPagedList(pageNumber, pageSize);
        }

        public IEnumerable<Produto> ObterProdutosEstoqueZerado()
        {
            return _produtoService.ObterProdutosEstoqueZerado();
        }


        public IEnumerable<Produto> ObtemPorFiltro(string pCodigo, string pNome, int pIdFabricante, int pIdModelo, int pFiltroQtdEstoque)
        {
            return _produtoService.ObtemPorFiltro(pCodigo, pNome, pIdFabricante, pIdModelo, pFiltroQtdEstoque);
        }
    }
}
