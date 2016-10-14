using System;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Linq;
using PagedList;
using System.Collections.Generic;

namespace Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaProdutoRepository _vendaProdutoRepository;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public VendaService(IVendaRepository vendaRepository, IProdutoRepository produtoRepository, IVendaProdutoRepository vendaProdutoRepository, IOcorrenciaRepository ocorrenciaRepository) : base(vendaRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _vendaProdutoRepository = vendaProdutoRepository;
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public IEnumerable<Venda> ObtemVendasOrdenado()
        {
            var lListaVendas = _vendaRepository.ObtemTodos().OrderByDescending(x => x.DataVenda);

            return lListaVendas;
        }


        public void GravarVenda(Venda lVenda)
        {
            //Gravando a Venda
            Venda lvendaAux = _vendaRepository.AddWithReturn(lVenda);
            int lIdVenda = lvendaAux.IdVenda;

            foreach (var item in lVenda.VendasProduto)
            {
                //Atualizando o estoque dos produtos vendidos
                Produto lProduto = _produtoRepository.ObtemPorId(item.IdProduto.GetValueOrDefault(0));
                lProduto.QtdEstoque = lProduto.QtdEstoque - item.QtdVendida;

                _produtoRepository.Update(lProduto);

                //Não é necessário pois na gravação da venda, já está gravando na tabela VENDAS_PRODUTO
                //////////Gravando VendasProduto
                ////////VendasProduto lVendasProduto = new VendasProduto();
                ////////lVendasProduto.IdVendas = lIdVenda;
                //////////lVendasProduto.Venda = lvendaAux;
                ////////lVendasProduto.IdUsuario = lVenda.IdUsuario;
                ////////lVendasProduto.IdProduto = lProduto.IdProduto;
                ////////lVendasProduto.QtdVendida = item.QtdVendida;
                ////////lVendasProduto.DataModificacao = DateTime.Now;

                ////////_vendaProdutoRepository.Add(lVendasProduto);

                //Gravando a Ocorrência
                Ocorrencia lOcorrencia = new Ocorrencia();
                lOcorrencia.DataOcorrencia = DateTime.Now;
                lOcorrencia.IdVenda = lIdVenda;
                lOcorrencia.IdProduto = lProduto.IdProduto;
                lOcorrencia.QtdProduto = item.QtdVendida;
                lOcorrencia.IdUsuario = lVenda.IdVendedor;
                lOcorrencia.TipoEvento = "VENDA";

                _ocorrenciaRepository.Add(lOcorrencia);
            }

        }

        public IEnumerable<Venda> ObtemPorFiltro(Venda lVenda)
        {
            return _vendaRepository.ObterPorFiltro(lVenda);
        }
    }
}
