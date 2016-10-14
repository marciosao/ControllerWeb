using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using ControllerWeb.ViewModels;
using PagedList;

namespace ControllerWeb.Controllers
{
    public class OcorrenciaController : BaseController
    {
        private readonly IOcorrenciaAppService _OcorrenciaApp;
        private readonly IVendaAppService _vendaApp;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;

        public OcorrenciaController(IOcorrenciaAppService ocorrenciaApp, IVendaAppService vendaApp, IVendedorAppService vendedorApp, IProdutoAppService produtoApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp)
        {
            _OcorrenciaApp = ocorrenciaApp;
            _vendaApp = vendaApp;
            _vendedorApp = vendedorApp;
            _produtoApp = produtoApp;
            _fabricanteApp = fabricanteApp;
            _modeloApp = modeloApp;
        }

        // GET: Ocorrencia
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);

            ViewBag.ListaTipoEvento = new SelectList(MontarTipoEvento(), "IdTipoEvento", "Nome", string.Empty);

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            List<ListaOcorrencias> lListaListaOcorrencias = new List<ListaOcorrencias>();
 
            PesquisaOcorrenciaViewModel lPesquisaOcorrenciaViewModel = new PesquisaOcorrenciaViewModel();

            var ocorrenciasPaginadas = (PagedList<ListaOcorrencias>)lListaListaOcorrencias.ToPagedList(pageNumber, 10);
            lPesquisaOcorrenciaViewModel.OcorrenciasPaginadas = ocorrenciasPaginadas;

            ViewBag.TotalRegistros = ocorrenciasPaginadas.TotalItemCount;

            return View(lPesquisaOcorrenciaViewModel);

        }

        [HttpPost]
        public ActionResult Index(PesquisaOcorrenciaViewModel pOcorenciaFiltros, int? page)
        {
            int pageNumber = (page ?? 1);

            Ocorrencia lOcorrenciaFiltro = new Ocorrencia();
            lOcorrenciaFiltro.DataOcorrencia = pOcorenciaFiltros.DataOcorrencia;
            lOcorrenciaFiltro.TipoEvento = pOcorenciaFiltros.TipoEvento;
            lOcorrenciaFiltro.IdUsuario = pOcorenciaFiltros.IdVendedor;

            var lOcorrencias = _OcorrenciaApp.ObtemOcorrenciaPorFiltroOrdenado(lOcorrenciaFiltro);

            List<ListaOcorrencias> lListaListaOcorrencias = new List<ListaOcorrencias>();
            foreach (var item in lOcorrencias)
            {
                ListaOcorrencias lListaOcorrencias = new ListaOcorrencias();

                lListaOcorrencias.TipoEvento = item.TipoEvento;
                if (item.IdVenda != null)
                {
                    lListaOcorrencias.IdVenda = item.IdVenda;
                }
                else
                {
                    lListaOcorrencias.IdVenda = 0;
                }

                if (item.IdDevolucao != null)
                {
                    lListaOcorrencias.IdDevolucao = item.IdDevolucao;
                }
                else
                {
                    lListaOcorrencias.Produto = "-";
                }

                lListaOcorrencias.IdProduto = item.IdProduto;
                lListaOcorrencias.QtdProduto = item.QtdProduto;
                lListaOcorrencias.DataOcorrencia = item.DataOcorrencia;
                lListaOcorrencias.IdUsuario = item.IdUsuario;

                Produto lProduto = _produtoApp.ObtemPorId(item.IdProduto.GetValueOrDefault(0));
                if (lProduto != null)
                {
                    lListaOcorrencias.Produto = lProduto.Nome + "-" + lProduto.Fabricante.Nome + "-" + lProduto.Modelo.Nome;
                }
                else
                {
                    lListaOcorrencias.Produto = "-";
                }

                Vendedor lVendedor = _vendedorApp.ObtemPorId(item.IdUsuario.GetValueOrDefault(0));
                if (lVendedor != null)
                {
                    lListaOcorrencias.Usuario = lVendedor.Nome;
                }
                else
                {
                    lListaOcorrencias.Usuario = "-";
                }

                lListaListaOcorrencias.Add(lListaOcorrencias);
            }

            ViewBag.ListaTipoEvento = new SelectList(MontarTipoEvento(), "IdTipoEvento", "Nome", string.Empty);

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            PesquisaOcorrenciaViewModel lPesquisaOcorrenciaViewModel = new PesquisaOcorrenciaViewModel();

            var ocorrenciasPaginadas = (PagedList<ListaOcorrencias>)lListaListaOcorrencias.ToPagedList(pageNumber, 10);
            lPesquisaOcorrenciaViewModel.OcorrenciasPaginadas = ocorrenciasPaginadas;

            ViewBag.TotalRegistros = ocorrenciasPaginadas.TotalItemCount;

            return View(lPesquisaOcorrenciaViewModel);
        }

        [HttpPost]
        public ActionResult GerarRelatorio(PesquisaOcorrenciaViewModel pOcorenciaFiltros)
        {
            return View(pOcorenciaFiltros);
        }
        private List<TipoEventoViewModel> MontarTipoEvento()
        {
            List<TipoEventoViewModel> lListaTipoEvento = new List<TipoEventoViewModel>();
            TipoEventoViewModel lTipoEvento1 = new TipoEventoViewModel();
            lTipoEvento1.IdTipoEvento = 1;
            lTipoEvento1.Nome = "VENDA";

            TipoEventoViewModel lTipoEvento2 = new TipoEventoViewModel();
            lTipoEvento2.IdTipoEvento = 2;
            lTipoEvento2.Nome = "ENTRADA NO ESTOQUE";

            TipoEventoViewModel lTipoEvento3 = new TipoEventoViewModel();
            lTipoEvento3.IdTipoEvento = 3;
            lTipoEvento3.Nome = "DEVOLUÇÃO";

            lListaTipoEvento.Add(lTipoEvento1);
            lListaTipoEvento.Add(lTipoEvento2);
            lListaTipoEvento.Add(lTipoEvento3);

            return lListaTipoEvento;
        }
    }
}
