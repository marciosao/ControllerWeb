using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Application
{
    public class DevolucaoProdutoAppService : AppServiceBase<DevolucaoProduto>,IDevolucaoProdutoAppService
    {
        private readonly IDevolucaoProdutoService _devolucaoProdutoService;

        public DevolucaoProdutoAppService(IDevolucaoProdutoService devolucaoProdutoService) : base(devolucaoProdutoService)
        {
            _devolucaoProdutoService = devolucaoProdutoService;
        }

        public IEnumerable<DevolucaoProduto> ObtemPorFiltro(Devolucao pDevolucao)
        {
            return _devolucaoProdutoService.ObtemPorFiltro(pDevolucao);
        }
    }
}

