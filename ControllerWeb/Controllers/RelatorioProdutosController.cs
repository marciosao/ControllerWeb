using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using ControllerWeb.ViewModels;
using System;
using ControllerWeb.Util;

namespace ControllerWeb.Controllers
{
    public class RelatorioProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;
        private readonly IOcorrenciaAppService _ocorrenciaApp;
        private readonly RelatorioAppService _relatorioApp;

        public RelatorioProdutosController(IProdutoAppService produtoApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp, IOcorrenciaAppService ocorrenciaApp, RelatorioAppService relatorioApp)
        {
            this._produtoApp = produtoApp;
            this._fabricanteApp = fabricanteApp;
            this._modeloApp = modeloApp;
            this._ocorrenciaApp = ocorrenciaApp;
            this._relatorioApp = relatorioApp;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();


            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            return View(_pesquisaProdutoViewModel);
        }

        [HttpPost]
        public ActionResult Index(PesquisaProdutoViewModel pProduto, int? page)
        {
            _relatorioApp.RelatorioProdutos(Response, pProduto);

            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            return View(pProduto);
        }

        [HttpPost]
        public JsonResult ObtemFabricantePorNome(string pIdFabricante)
        {
            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemFabricantePorNome(pIdFabricante), "IdFabricante", "Nome");

            return Json(ViewBag.IdFabricante, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtemModeloPorNome(string pModelo)
        {
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemModeloPorNome(pModelo), "IdModelo", "Nome");

            return Json(ViewBag.IdModelo, JsonRequestBehavior.AllowGet);
        }
    }
}