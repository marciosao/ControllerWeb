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

    public class RelatorioDevolucaoController : BaseController
    {
        private readonly IDevolucaoAppService _devolucaoAppService;
        private readonly IDevolucaoProdutoAppService _devolucaoProdutoAppService;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IModeloAppService _modeloApp;
        private readonly RelatorioAppService _relatorioApp;
        public RelatorioDevolucaoController(IDevolucaoAppService devolucaoAppService, IDevolucaoProdutoAppService devolucaoProdutoAppService, IVendedorAppService vendedorApp, IProdutoAppService produtoApp, IModeloAppService modeloApp, RelatorioAppService relatorioApp)
        {
            _devolucaoProdutoAppService = devolucaoProdutoAppService;
            _devolucaoAppService = devolucaoAppService;
            _vendedorApp = vendedorApp;
            _produtoApp = produtoApp;
            _modeloApp = modeloApp;
            _relatorioApp = relatorioApp;
        }
        // GET: RelatorioDevolucao
        public ActionResult Index()
        {
            DevolucaoViewModel _pesquisaDevolucaoViewModel = new DevolucaoViewModel();

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            return View(_pesquisaDevolucaoViewModel);
        }

        [HttpPost]
        public ActionResult Index(DevolucaoViewModel pDevolucao)
        {

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            _relatorioApp.RelatorioDevolucao(Response, pDevolucao);

            return View(pDevolucao);
        }

    }
}
