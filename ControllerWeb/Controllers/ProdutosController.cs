using Application.Interfaces;
using Domain.Entities;
//using ControllerWeb.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using ControllerWeb.ViewModels;
using PagedList;
using System;
using ControllerWeb.Util;

namespace ControllerWeb.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;
        private readonly IOcorrenciaAppService _ocorrenciaApp;
        private readonly RelatorioAppService _relatorioApp;

        public ProdutosController(IProdutoAppService produtoApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp, IOcorrenciaAppService ocorrenciaApp, RelatorioAppService relatorioApp)
        {
            this._produtoApp = produtoApp;
            this._fabricanteApp = fabricanteApp;
            this._modeloApp = modeloApp;
            this._ocorrenciaApp = ocorrenciaApp;
            this._relatorioApp = relatorioApp;
        }

        // GET: Produtos
        public ActionResult Index(int? page)
        {
            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();

            int pageNumber = (page ?? 1);

            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            var produtoViewModel = _produtoApp.ObtemTodos();
            var ProdutosPaginados = (PagedList<Produto>)produtoViewModel.ToPagedList(pageNumber, 10);
            ViewBag.TotalRegistros = ProdutosPaginados.TotalItemCount;

            _pesquisaProdutoViewModel.ListaProdutosPaginado = ProdutosPaginados;
            return View(_pesquisaProdutoViewModel);
        }

        [HttpPost]
        public ActionResult Index(PesquisaProdutoViewModel pProduto, int? page)
        {
            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();
            Produto lProduto = new Produto();

            lProduto.Nome = pProduto.Nome;
            lProduto.IdFabricante = pProduto.IdFabricante;
            lProduto.IdModelo = pProduto.IdModelo;
            lProduto.Codigo = pProduto.Codigo;

            int pageNumber = (page ?? 1);

            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            var produtoViewModel = _produtoApp.ObtemPorFiltro(lProduto);

            _pesquisaProdutoViewModel.ListaProdutosPaginado = (PagedList<Produto>)produtoViewModel.ToPagedList(pageNumber, 10);

            var ProdutosPaginados = (PagedList<Produto>)produtoViewModel.ToPagedList(pageNumber, 10);
            ViewBag.TotalRegistros = ProdutosPaginados.TotalItemCount;

            return View(_pesquisaProdutoViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var lProduto = _produtoApp.ObtemPorId(id);

            return View(lProduto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto pProduto)
        {
            if (ModelState.IsValid)
            {
                _produtoApp.Salvar(pProduto);

                return RedirectToAction("Index");
            }

            //ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            //ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            return View(pProduto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var lProduto = _produtoApp.ObtemPorId(id);

            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemFabricantePorFiltro(lProduto.Fabricante), "IdFabricante", "Nome");
            ViewBag.IdFabricanteSelecionado = lProduto.Fabricante.IdFabricante;
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemModeloPorFiltro(lProduto.Modelo), "IdModelo", "Nome");
            ViewBag.IdModeloSelecionado = lProduto.Modelo.IdModelo;

            return View(lProduto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto pProdutoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lProduto = pProdutoViewModel;
                _produtoApp.Update(lProduto);

                return RedirectToAction("Index");
            }

            ViewBag.IdFabricante = new SelectList(_fabricanteApp.ObtemTodos(), "IdFabricante", "Nome");
            ViewBag.IdModelo = new SelectList(_modeloApp.ObtemTodos(), "IdModelo", "Nome");

            return View(pProdutoViewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var lProduto = _produtoApp.ObtemPorId(id);

            return View(lProduto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lProduto = _produtoApp.ObtemPorId(id);
            _produtoApp.Remove(lProduto);

            return RedirectToAction("Index");
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

        public ActionResult PesquisarProdutoAdicionarEstoque(int pIdCodigoProduto)
        {
            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();

            var produtoViewModel = _produtoApp.ObtemPorId(pIdCodigoProduto);

            _pesquisaProdutoViewModel.ListaProdutos = this.MontaProduto(produtoViewModel);

            return PartialView("~/Views/Produtos/PartialEntradaEstoque.cshtml", _pesquisaProdutoViewModel);
        }

        private List<PesquisaProdutos> MontaProduto(Produto produtos)
        {
            List<PesquisaProdutos> lListaProdutoVM = new List<PesquisaProdutos>();

            PesquisaProdutos lProdutoVM = new PesquisaProdutos();

            lProdutoVM.IdProduto = produtos.IdProduto;
            lProdutoVM.Codigo = produtos.Codigo;
            lProdutoVM.Nome = produtos.Nome;
            lProdutoVM.QtdEstoque = produtos.QtdEstoque;
            lProdutoVM.QtdMinimaEstoque = produtos.QtdMinimaEstoque;
            if (produtos.Fabricante != null)
            {
                lProdutoVM.IdFabricante = produtos.Fabricante.IdFabricante;
                lProdutoVM.Fabricante = produtos.Fabricante.Nome;
            }

            if (produtos.Modelo != null)
            {
                lProdutoVM.IdModelo = produtos.Modelo.IdModelo;
                lProdutoVM.Modelo = produtos.Modelo.Nome;
            }

            lProdutoVM.AvisaEstoqueMinimo = produtos.AvisaEstoqueMinimo;

            lListaProdutoVM.Add(lProdutoVM);


            return lListaProdutoVM;
        }

        public JsonResult GravarEntradaEstoque(ProdutoSelecionado ProdutoSelecionado)
        {
            Produto lProduto = new Produto();
            Ocorrencia lOcorrencia = new Ocorrencia();
            lProduto = _produtoApp.ObtemPorId(ProdutoSelecionado.IdProduto);
            lProduto.QtdEstoque += ProdutoSelecionado.QuantidadeVendida;

            _produtoApp.Update(lProduto);

            lOcorrencia.DataOcorrencia = DateTime.Now;
            lOcorrencia.IdProduto = lProduto.IdProduto;
            lOcorrencia.IdUsuario = 1;
            lOcorrencia.QtdProduto = ProdutoSelecionado.QuantidadeVendida;
            lOcorrencia.TipoEvento = "ENTRADA NO ESTOQUE";

            _ocorrenciaApp.Add(lOcorrencia);

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult GerarRelatorio(PesquisaProdutoViewModel pProduto)
        {
            _relatorioApp.RelatorioProdutos(Response, pProduto);

            return View(pProduto);
        }

        public ActionResult PesquisarItensEstoqueZerado(int? page)
        {
            int pageNumber = (page ?? 1);

            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();

            var produtoViewModel = _produtoApp.ObterProdutosEstoqueZerado();

            _pesquisaProdutoViewModel.Produtos = produtoViewModel;

            _pesquisaProdutoViewModel.ListaProdutos = this.MontaListaProdutos(_pesquisaProdutoViewModel.Produtos);

            var ProdutosPaginados = (PagedList<Produto>)produtoViewModel.ToPagedList(pageNumber, 10);
            ViewBag.TotalRegistros = ProdutosPaginados.TotalItemCount;

            return PartialView("~/Views/Produtos/PartialItensEstoqueZerado.cshtml", _pesquisaProdutoViewModel);
        }
        private List<PesquisaProdutos> MontaListaProdutos(IEnumerable<Produto> produtos)
        {
            List<PesquisaProdutos> lListaProdutoVM = new List<PesquisaProdutos>();
            foreach (var item in produtos)
            {
                PesquisaProdutos lProdutoVM = new PesquisaProdutos();

                lProdutoVM.IdProduto = item.IdProduto;
                lProdutoVM.Codigo = item.Codigo;
                lProdutoVM.Nome = item.Nome;
                lProdutoVM.QtdEstoque = item.QtdEstoque;
                lProdutoVM.QtdMinimaEstoque = item.QtdMinimaEstoque;
                if (item.Fabricante != null)
                {
                    lProdutoVM.IdFabricante = item.Fabricante.IdFabricante;
                    lProdutoVM.Fabricante = item.Fabricante.Nome;
                }

                if (item.Modelo != null)
                {
                    lProdutoVM.IdModelo = item.Modelo.IdModelo;
                    lProdutoVM.Modelo = item.Modelo.Nome;
                }

                lProdutoVM.AvisaEstoqueMinimo = item.AvisaEstoqueMinimo;

                lListaProdutoVM.Add(lProdutoVM);
            }

            return lListaProdutoVM;
        }

        [HttpGet]
        public JsonResult AutoCompletarFabricantesLeave(string query)
        {
            List<Fabricante> ListaFabricante = (List<Fabricante>)_fabricanteApp.ObtemFabricantePorNome(query);
            List<AutoComplete> comp = new List<AutoComplete>();
            foreach (var item in ListaFabricante)
            {
                AutoComplete lFabricanteAutoComplete = new AutoComplete();
                lFabricanteAutoComplete.Id = item.IdFabricante.ToString();
                lFabricanteAutoComplete.Nome = item.Nome;

                comp.Add(lFabricanteAutoComplete);
            }

            List<string> resultado = new List<string>();

            for (int i = 0; i < comp.Count; i++)
            {
                resultado.Add(comp[i].Id + " - " + comp[i].Nome);
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
