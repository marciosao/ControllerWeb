using Application.Interfaces;
using ControllerWeb.ViewModels;
using Domain.Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ControllerWeb.Util
{
    public class RelatorioAppService
    {
        private const string DATASET_DEVOLUCAO = "Devolucao";
        private const string DATASET_VENDAS = "Vendas";
        private const string DATASET_PRODUTOS = "Produtos";
        private const string DATASET_ESTOQUE = "Estoque";
        private const string DATASET_OCORRENCIA = "Ocorrencias";

        private readonly IDevolucaoAppService _devolucaoApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;
        private readonly IVendaAppService _vendaApp;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IOcorrenciaAppService _ocorrenciaApp;
        private readonly IVendaProdutoAppService _vendaProdutoApp;
        private readonly IOcorrenciaAppService _OcorrenciaApp;
        private readonly IDevolucaoProdutoAppService _devolucaoProdutoApp;

        public RelatorioAppService(IDevolucaoAppService devolucaoApp, IProdutoAppService produtoApp, IVendaAppService vendaApp, IOcorrenciaAppService ocorrenciaApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp, IVendedorAppService vendedorApp, IVendaProdutoAppService vendaProdutoApp, IDevolucaoProdutoAppService devolucaoProdutoApp, IOcorrenciaAppService OcorrenciaApp)
        {
            _devolucaoApp = devolucaoApp;
            _produtoApp = produtoApp;
            _vendaApp = vendaApp;
            _ocorrenciaApp = ocorrenciaApp;
            _fabricanteApp = fabricanteApp;
            _modeloApp = modeloApp;
            _vendedorApp = vendedorApp;
            _vendaProdutoApp = vendaProdutoApp;
            _devolucaoProdutoApp = devolucaoProdutoApp;
            _OcorrenciaApp = OcorrenciaApp;
        }


        public void RelatorioVendas(System.Web.HttpResponseBase response, PesquisaVendasViewModel pFiltrosVenda)
        {
            IDictionary<string, IEnumerable> dadosRelatorio = GerarRelatorioVendas(pFiltrosVenda);
            GerarPDF(response, "Relatorio de Vendas", @"Relatorios\relVendas.rdlc", dadosRelatorio);
        }

        private IDictionary<string, IEnumerable> GerarRelatorioVendas(PesquisaVendasViewModel pFiltrosVenda)
        {
            IDictionary<string, IEnumerable> resultado = new Dictionary<string, IEnumerable>();
            Venda lVenda = new Venda();

            lVenda.Codigo = pFiltrosVenda.Codigo;
            lVenda.DataVenda = pFiltrosVenda.DataVenda;
            lVenda.IdVendedor = pFiltrosVenda.IdVendedor;

            IEnumerable<Venda> tabelaVendas = _vendaApp.ObtemPorFiltro(lVenda);
            List<VendaRelatorio> lListaVendaRelatorio = new List<VendaRelatorio>();
            foreach (var rowVendas in tabelaVendas)
            {
                ////////Vendedor lVendedor = _vendedorApp.ObtemPorId(rowVendas.IdVendedor.GetValueOrDefault(0));

                ////////VendasProduto lVendasProduto = new VendasProduto();
                ////////lVendasProduto.IdVendas = rowVendas.IdVenda;

                var lListaVendasProduto = rowVendas.VendasProduto.Distinct();

                ////////foreach (var rowVendasProduto in lListaVendasProduto)
                foreach (var rowVendasProduto in lListaVendasProduto)
                {
                    VendaRelatorio lVendaRelatorio = new VendaRelatorio();

                    lVendaRelatorio.Id = rowVendas.IdVenda;
                    lVendaRelatorio.Vendedor = rowVendas.Vendedor.Nome;
                    lVendaRelatorio.CodVendedor = rowVendas.Vendedor.ToString();
                    lVendaRelatorio.MatriculaVendedor = rowVendas.Vendedor.Matricula;
                    lVendaRelatorio.DataVenda = rowVendas.DataVenda.Date;
                    lVendaRelatorio.DataModificacao = rowVendas.DataModificacao.ToString();
                    lVendaRelatorio.UsuarioResponsavel = rowVendas.IdUsuario;
                    lVendaRelatorio.CodigoVenda = rowVendas.Codigo;
                    ////////lVendaRelatorio.Vendedor = lVendedor.Nome;
                    ////////lVendaRelatorio.CodVendedor = lVendedor.IdVendedor.ToString();
                    ////////lVendaRelatorio.MatriculaVendedor = lVendedor.Matricula;

                    lVendaRelatorio.IdProduto = rowVendasProduto.Produto.IdProduto.ToString();
                    lVendaRelatorio.CodProduto = rowVendasProduto.Produto.Codigo;
                    lVendaRelatorio.Produto = rowVendasProduto.Produto.Nome;
                    lVendaRelatorio.QtdVendida = rowVendasProduto.QtdVendida.ToString();

                    if (rowVendasProduto.Produto.Fabricante != null)
                    {
                        lVendaRelatorio.Fabricante = rowVendasProduto.Produto.Fabricante.Nome;
                        lVendaRelatorio.CodFabricante = rowVendasProduto.Produto.Fabricante.IdFabricante.ToString();
                    }

                    if (rowVendasProduto.Produto.Modelo != null)
                    {
                        lVendaRelatorio.Modelo = rowVendasProduto.Produto.Modelo.Nome;
                        lVendaRelatorio.CodModelo = rowVendasProduto.Produto.Modelo.IdModelo.ToString();
                    }

                    lListaVendaRelatorio.Add(lVendaRelatorio);
                }
            }

            resultado.Add(DATASET_VENDAS, lListaVendaRelatorio);

            List<FiltrosVendaRelatorio> lListaFiltrosVendaRelatorio = new List<FiltrosVendaRelatorio>();
            FiltrosVendaRelatorio lFiltrosVendaRelatorio = new FiltrosVendaRelatorio();
            lFiltrosVendaRelatorio.ftVendedor = (pFiltrosVenda.IdVendedor > 0 ? _vendedorApp.ObtemPorId(pFiltrosVenda.IdVendedor.GetValueOrDefault(0)).Nome : "-");
            lFiltrosVendaRelatorio.ftData = (pFiltrosVenda.DataVenda != null && !pFiltrosVenda.DataVenda.Date.ToShortDateString().Equals("01/01/0001")) ? pFiltrosVenda.DataVenda.ToShortDateString() : "-";
            lFiltrosVendaRelatorio.ftProduto = (pFiltrosVenda.IdProduto > 0 ? _produtoApp.ObtemPorId(pFiltrosVenda.IdProduto.GetValueOrDefault(0)).Nome : "-");

            lListaFiltrosVendaRelatorio.Add(lFiltrosVendaRelatorio);

            resultado.Add(DATASET_VENDAS + "1", lListaFiltrosVendaRelatorio);

            return resultado;
        }


        public void RelatorioProdutos(System.Web.HttpResponseBase response, PesquisaProdutoViewModel pFiltrosProdutos)
        {
            IDictionary<string, IEnumerable> dadosRelatorio = GerarRelatorioProdutos(pFiltrosProdutos);
            GerarPDF(response, "Relatorio de Produtos", @"Relatorios\relProdutos.rdlc", dadosRelatorio);
        }

        private IDictionary<string, IEnumerable> GerarRelatorioProdutos(PesquisaProdutoViewModel pFiltrosProdutos)
        {
            IDictionary<string, IEnumerable> resultado = new Dictionary<string, IEnumerable>();

            Produto lProduto = new Produto();
            lProduto.Codigo = pFiltrosProdutos.Codigo;
            lProduto.Nome = pFiltrosProdutos.Nome;
            lProduto.IdFabricante = pFiltrosProdutos.IdFabricante;
            lProduto.IdModelo = pFiltrosProdutos.IdModelo;

            string Codigo = string.Empty;
            string Nome = string.Empty;
            int IdFabricante = 0;
            int IdModelo = 0;
            int FiltroQtdEstoque = 0;

            if (!string.IsNullOrEmpty(pFiltrosProdutos.Codigo))
            {
                Codigo = pFiltrosProdutos.Codigo;
            }

            if (!string.IsNullOrEmpty(pFiltrosProdutos.Nome))
            {
                Nome = pFiltrosProdutos.Nome;
            }

            if (pFiltrosProdutos.IdFabricante != null && pFiltrosProdutos.IdFabricante > 0)
            {
                IdFabricante = pFiltrosProdutos.IdFabricante;
            }

            if (pFiltrosProdutos.IdModelo != null && pFiltrosProdutos.IdModelo > 0)
            {
                IdModelo = pFiltrosProdutos.IdModelo;
            }

            if (!string.IsNullOrEmpty(pFiltrosProdutos.FiltroQtdEstoque))
            {
                FiltroQtdEstoque = int.Parse(pFiltrosProdutos.FiltroQtdEstoque);
            }

            ////////IEnumerable<Produto> tabelaProdutos = _produtoApp.ObtemPorFiltro(lProduto);
            IEnumerable<Produto> tabelaProdutos = _produtoApp.ObtemPorFiltro(Codigo,Nome,IdFabricante,IdModelo,FiltroQtdEstoque);
            List<ProdutoRelatorio> lListaProdutoRelatorio = new List<ProdutoRelatorio>();
            foreach (var item in tabelaProdutos)
            {
                ProdutoRelatorio lProdutoRelatorio = new ProdutoRelatorio();
                lProdutoRelatorio.Id = item.IdProduto;
                lProdutoRelatorio.Codigo = item.Codigo;
                lProdutoRelatorio.Nome = item.Nome;
                if (item.Fabricante != null)
                {
                    lProdutoRelatorio.CodFabricante = item.Fabricante.IdFabricante.ToString();
                    lProdutoRelatorio.Fabricante = item.Fabricante.Nome;
                }
                else
                {
                    lProdutoRelatorio.Fabricante = "-";
                }

                if (item.Modelo != null)
                {
                    lProdutoRelatorio.CodModelo = item.Modelo.IdModelo.ToString();
                    lProdutoRelatorio.Modelo = item.Modelo.Nome;
                }
                else
                {
                    lProdutoRelatorio.Modelo = "-";
                }

                lProdutoRelatorio.QuantidadeEstoque = item.QtdEstoque.ToString();
                lProdutoRelatorio.QuantidadeMinimaEstoque = item.QtdMinimaEstoque.ToString();
                lProdutoRelatorio.AvisaQuantidadeMinima = (item.AvisaEstoqueMinimo ? "Sim" : "Não");

                lListaProdutoRelatorio.Add(lProdutoRelatorio);
            }

            List<FiltrosProdutoRelatorio> lListaFiltrosProdutoRelatorio = new List<FiltrosProdutoRelatorio>();
            FiltrosProdutoRelatorio lFiltrosProdutoRelatorio = new FiltrosProdutoRelatorio();
            lFiltrosProdutoRelatorio.ftFabricante = (pFiltrosProdutos.IdFabricante > 0 ? _fabricanteApp.ObtemPorId(pFiltrosProdutos.IdFabricante).Nome : "-");
            lFiltrosProdutoRelatorio.ftModelo = (pFiltrosProdutos.IdModelo > 0 ? _modeloApp.ObtemPorId(pFiltrosProdutos.IdModelo).Nome : "-");
            lFiltrosProdutoRelatorio.ftSituacaoEstoque = "-";
            lFiltrosProdutoRelatorio.ftProduto = pFiltrosProdutos.Nome;
            lListaFiltrosProdutoRelatorio.Add(lFiltrosProdutoRelatorio);

            ////////resultado.Add(DATASET_PRODUTOS, tabelaProdutos);
            resultado.Add(DATASET_PRODUTOS, (IEnumerable<ProdutoRelatorio>)lListaProdutoRelatorio);
            resultado.Add(DATASET_PRODUTOS + "1", (IEnumerable<FiltrosProdutoRelatorio>)lListaFiltrosProdutoRelatorio);

            return resultado;
        }


        public void RelatorioOcorrencias(System.Web.HttpResponseBase response, Ocorrencia pFiltrosOcorrencia)
        {
            IDictionary<string, IEnumerable> dadosRelatorio = GerarRelatorioOcorrencias(pFiltrosOcorrencia);
            GerarPDF(response, "Relatorio de Ocorrencias", @"Relatorios\relOcorrencias.rdlc", dadosRelatorio);
        }

        private IDictionary<string, IEnumerable> GerarRelatorioOcorrencias(Ocorrencia pFiltrosOcorrencia)
        {
            IDictionary<string, IEnumerable> resultado = new Dictionary<string, IEnumerable>();

            IEnumerable<Ocorrencia> tabelaOcorrencias = _OcorrenciaApp.ObtemOcorrenciaPorFiltroOrdenado(pFiltrosOcorrencia);

            resultado.Add(DATASET_OCORRENCIA, tabelaOcorrencias);

            return resultado;
        }


        public void RelatorioDevolucao(System.Web.HttpResponseBase response, DevolucaoViewModel pFiltrosDevolucao)
        {
            IDictionary<string, IEnumerable> dadosRelatorio = GerarRelatorioDevolucao(pFiltrosDevolucao);
            GerarPDF(response, "Relatorio de Devolucao", @"Relatorios\relDevolucao.rdlc", dadosRelatorio);
        }

        private IDictionary<string, IEnumerable> GerarRelatorioDevolucao(DevolucaoViewModel pFiltrosDevolucao)
        {
            IDictionary<string, IEnumerable> resultado = new Dictionary<string, IEnumerable>();

            Devolucao lDevolucao = new Devolucao();

            if (pFiltrosDevolucao.DataDevolucao != null && !pFiltrosDevolucao.DataDevolucao.ToString().Equals("01/01/0001 00:00:00"))
            {
                lDevolucao.DataDevolucao = pFiltrosDevolucao.DataDevolucao;
            }

            if (pFiltrosDevolucao.IdVendedor > 0)
            {
                lDevolucao.IdVendedor = pFiltrosDevolucao.IdVendedor;
            }

            if (!string.IsNullOrEmpty(pFiltrosDevolucao.Produto))
            {
                lDevolucao.DevolucaoProduto = new List<DevolucaoProduto>();
                DevolucaoProduto lDevolucaoProdutoAux = new DevolucaoProduto();
                lDevolucaoProdutoAux.Produto = new Produto();
                lDevolucaoProdutoAux.Produto.Nome = pFiltrosDevolucao.Produto;
                lDevolucao.DevolucaoProduto.Add(lDevolucaoProdutoAux);
            }


            IEnumerable<Devolucao> tabelaDevolucao = _devolucaoApp.ObtemDevolucoesPorFiltroOrdenado(lDevolucao);
            List<DevolucaoRelatorio> lListaDevolucaoRelatorio = new List<DevolucaoRelatorio>();
            foreach (var rowDevolucao in tabelaDevolucao)
            {
                var lListaDevolucaoProduto = _devolucaoProdutoApp.ObtemPorFiltro(rowDevolucao);

                foreach (var rowDevolucaoProduto in lListaDevolucaoProduto)
                {
                    DevolucaoRelatorio lDevolucaoRelatorio = new DevolucaoRelatorio();

                    lDevolucaoRelatorio.Id = rowDevolucao.IdDevolucao;
                    lDevolucaoRelatorio.DataDevolucao = rowDevolucao.DataDevolucao.Date;
                    lDevolucaoRelatorio.Vendedor = rowDevolucao.Vendedor.Nome;

                    lDevolucaoRelatorio.Produto = rowDevolucaoProduto.Produto.Nome;
                    lDevolucaoRelatorio.Fabricante = rowDevolucaoProduto.Produto.Fabricante.Nome;
                    lDevolucaoRelatorio.Modelo = rowDevolucaoProduto.Produto.Modelo.Nome;
                    lDevolucaoRelatorio.QuantidadeDevolvida = rowDevolucaoProduto.QtdDevolvida.ToString();

                    lListaDevolucaoRelatorio.Add(lDevolucaoRelatorio);
                }
            }

            resultado.Add(DATASET_DEVOLUCAO, lListaDevolucaoRelatorio);

            List<FiltrosDevolucaoRelatorio> lListaFiltrosDevolucaoRelatorio = new List<FiltrosDevolucaoRelatorio>();
            FiltrosDevolucaoRelatorio lFiltrosDevolucaoRelatorio = new FiltrosDevolucaoRelatorio();
            lFiltrosDevolucaoRelatorio.ftVendedor = (pFiltrosDevolucao.IdVendedor > 0 ? _vendedorApp.ObtemPorId(pFiltrosDevolucao.IdVendedor).Nome : "-");
            lFiltrosDevolucaoRelatorio.ftDataDevolucao = (pFiltrosDevolucao.DataDevolucao != null && !pFiltrosDevolucao.DataDevolucao.ToString().Equals("01/01/0001 00:00:00")) ? pFiltrosDevolucao.DataDevolucao.ToShortDateString() : "-";
            ////////lFiltrosDevolucaoRelatorio.ftProduto = (pFiltrosDevolucao.Produto.Any())? _produtoApp.ObtemPorId(pFiltrosDevolucao.Produto.).Nome : "-");

            lListaFiltrosDevolucaoRelatorio.Add(lFiltrosDevolucaoRelatorio);

            resultado.Add(DATASET_DEVOLUCAO + "1", lListaFiltrosDevolucaoRelatorio);

            return resultado;
        }


        private void GerarPDF(System.Web.HttpResponseBase response, string prefixo, string templatePath, IDictionary<string, IEnumerable> dadosRelatorio)
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = templatePath;

            int dataSetOrdem = 0;

            foreach (IEnumerable table in dadosRelatorio.Values)
            {
                dataSetOrdem++;
                viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet" + dataSetOrdem, table));
            }

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            string nomeArquivo = GerarNomeRelatorio(prefixo, extension, dadosRelatorio);

            response.Buffer = true;
            response.Clear();
            response.ContentType = mimeType;
            response.AddHeader("content-disposition", "attachment; filename= " + nomeArquivo);
            response.BinaryWrite(bytes);
            response.Flush();
        }

        private string GerarNomeRelatorio(string prefixo, string extensao, IDictionary<string, IEnumerable> dadosRelatorio)
        {
            StringBuilder str = new StringBuilder(prefixo);

            str.Append("-" + DateTime.Now.ToString());
            str.Append("." + extensao);
            str.Replace(" ", "");

            return str.ToString();
        }
    }
}