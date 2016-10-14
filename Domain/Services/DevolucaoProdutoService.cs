using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class DevolucaoProdutoService : ServiceBase<DevolucaoProduto>,IDevolucaoProdutoService
    {
        private readonly IDevolucaoProdutoRepository _devolucaoProdutoRepository;

        public DevolucaoProdutoService(IDevolucaoProdutoRepository devolucaoProdutoRepository) : base(devolucaoProdutoRepository)
        {
            _devolucaoProdutoRepository = devolucaoProdutoRepository;
        }

        public IEnumerable<DevolucaoProduto> ObtemPorFiltro(Devolucao pDevolucao)
        {
            return _devolucaoProdutoRepository.ObtemPorFiltro(pDevolucao);
        }
    }
}

