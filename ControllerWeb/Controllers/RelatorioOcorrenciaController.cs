using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using ControllerWeb.ViewModels;
using System;
using PagedList;
using ControllerWeb.Util;

namespace ControllerWeb.Controllers
{
    public class RelatorioOcorrenciaController : BaseController
    {
        private readonly IVendaAppService _vendaApp;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;
        private readonly RelatorioAppService _relatorioApp;

        public RelatorioOcorrenciaController(IVendaAppService vendaApp, IVendedorAppService vendedorApp, IProdutoAppService produtoApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp, RelatorioAppService relatorioApp)
        {
            this._vendaApp = vendaApp;
            this._vendedorApp = vendedorApp;
            this._produtoApp = produtoApp;
            this._fabricanteApp = fabricanteApp;
            this._modeloApp = modeloApp;
            this._relatorioApp = relatorioApp;
        }
        // GET: RelatorioOcorrencia
        public ActionResult Index()
        {
            ViewBag.ListaTipoEvento = new SelectList(MontarTipoEvento(), "IdTipoEvento", "Nome", string.Empty);

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            return View();
        }

        [HttpPost]
        public ActionResult Index(PesquisaOcorrenciaViewModel pOcorenciaFiltros)
        {
            Ocorrencia lOcorrenciaFiltro = new Ocorrencia();
            lOcorrenciaFiltro.DataOcorrencia = pOcorenciaFiltros.DataOcorrencia;
            lOcorrenciaFiltro.TipoEvento = pOcorenciaFiltros.TipoEvento;
            lOcorrenciaFiltro.IdUsuario = pOcorenciaFiltros.IdVendedor;

            _relatorioApp.RelatorioOcorrencias(Response, lOcorrenciaFiltro);

            return View();
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