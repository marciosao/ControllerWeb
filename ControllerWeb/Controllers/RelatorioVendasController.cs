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
    public class RelatorioVendasController : BaseController
    {
        private readonly IVendaAppService _vendaApp;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;
        private readonly RelatorioAppService _relatorioApp;

        public RelatorioVendasController(IVendaAppService vendaApp, IVendedorAppService vendedorApp, IProdutoAppService produtoApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp, RelatorioAppService relatorioApp)
        {
            this._vendaApp = vendaApp;
            this._vendedorApp = vendedorApp;
            this._produtoApp = produtoApp;
            this._fabricanteApp = fabricanteApp;
            this._modeloApp = modeloApp;
            this._relatorioApp = relatorioApp;
        }

        // GET: Vendas
        public ActionResult Index()
        {
            PesquisaVendasViewModel _pesquisaVendasViewModel = new PesquisaVendasViewModel();

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            return View(_pesquisaVendasViewModel);
        }

        [HttpPost]
        public ActionResult Index(PesquisaVendasViewModel pVendaFiltros)
        {
            _relatorioApp.RelatorioVendas(Response, pVendaFiltros);

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            return View(pVendaFiltros);
        }
    }
}