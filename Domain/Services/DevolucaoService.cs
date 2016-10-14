using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Linq;

namespace Domain.Services
{
    public class DevolucaoService : ServiceBase<Devolucao>,IDevolucaoService
    {
        private readonly IDevolucaoRepository _devolucaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IDevolucaoProdutoRepository _devolucaoProdutoRepository;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public DevolucaoService(IDevolucaoRepository devolucaoRepository, IProdutoRepository produtoRepository, IDevolucaoProdutoRepository devolucaoProdutoRepository, IOcorrenciaRepository ocorrenciaRepository) : base(devolucaoRepository)
        {
            _devolucaoRepository = devolucaoRepository;
            _produtoRepository = produtoRepository;
            _devolucaoProdutoRepository = devolucaoProdutoRepository;
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public void GravarDevolucao(Devolucao lDevolucao)
        {
            Devolucao lDevolucaoAux = _devolucaoRepository.AddWithReturn(lDevolucao);
            int lIdDevolucao = lDevolucaoAux.IdDevolucao;

            foreach (var item in lDevolucao.DevolucaoProduto)
            {
                //Atualizando o estoque dos produtos vendidos
                Produto lProduto = _produtoRepository.ObtemPorId(item.IdProduto.GetValueOrDefault(0));
                lProduto.QtdEstoque = lProduto.QtdEstoque + item.QtdDevolvida;

                _produtoRepository.Update(lProduto);

                //////////Gravando DevolucaoProduto
                ////////DevolucaoProduto lDevolucaoProduto = new DevolucaoProduto();
                ////////lDevolucaoProduto.IdDevolucao = lIdDevolucao;
                ////////lDevolucaoProduto.IdProduto = lProduto.IdProduto;
                ////////lDevolucaoProduto.QtdDevolvida= item.QtdDevolvida;

                ////////_devolucaoProdutoRepository.Add(lDevolucaoProduto);

                //Gravando a Ocorrência
                Ocorrencia lOcorrencia = new Ocorrencia();
                lOcorrencia.DataOcorrencia = DateTime.Now;
                lOcorrencia.IdDevolucao = lIdDevolucao;
                lOcorrencia.IdProduto = lProduto.IdProduto;
                lOcorrencia.QtdProduto = item.QtdDevolvida;
                lOcorrencia.IdUsuario = lDevolucao.IdVendedor;
                lOcorrencia.TipoEvento = "DEVOLUCAO";

                _ocorrenciaRepository.Add(lOcorrencia);
            }
        }

        public IEnumerable<Devolucao> ObtemDevolucoesOrdenado()
        {
            var lListaDevolucoes = _devolucaoRepository.ObtemTodos().OrderByDescending(x => x.DataDevolucao);

            return lListaDevolucoes;
        }

        public IEnumerable<Devolucao> ObtemDevolucoesPorFiltroOrdenado(Devolucao pDevolucao)
        {
            var lListaDevolucoes = this.ObtemDevolucoesPorFiltro(pDevolucao).OrderByDescending(x => x.DataDevolucao);

            return lListaDevolucoes;
        }

        public IEnumerable<Devolucao> ObtemDevolucoesPorFiltro(Devolucao pDevolucao)
        {
            var lListaDevolucoes = _devolucaoRepository.ObtemDevolucoesPorFiltro(pDevolucao);

            return lListaDevolucoes;
        }
    }
}
