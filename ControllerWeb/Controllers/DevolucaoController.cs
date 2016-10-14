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
    public class DevolucaoController : BaseController
    {
        private readonly IDevolucaoAppService _devolucaoAppService;
        private readonly IDevolucaoProdutoAppService _devolucaoProdutoAppService;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IModeloAppService _modeloApp;
        private readonly RelatorioAppService _relatorioApp;

        public DevolucaoController(IDevolucaoAppService devolucaoAppService, IDevolucaoProdutoAppService devolucaoProdutoAppService, IVendedorAppService vendedorApp, IProdutoAppService produtoApp, IModeloAppService modeloApp, RelatorioAppService relatorioApp)
        {
            _devolucaoProdutoAppService = devolucaoProdutoAppService;
            _devolucaoAppService = devolucaoAppService;
            _vendedorApp = vendedorApp;
            _produtoApp = produtoApp;
            _modeloApp = modeloApp;
            _relatorioApp = relatorioApp;
        }

        // GET: Devolucao
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);

            DevolucaoViewModel _pesquisaDevolucaoViewModel = new DevolucaoViewModel();

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", "Grilberto");

            var devolucoes = _devolucaoAppService.ObtemDevolucoesOrdenado();
            var devolucoesPaginadas = (PagedList<Devolucao>)devolucoes.ToPagedList(pageNumber, 10);

            _pesquisaDevolucaoViewModel.DevolucaoPaginada = devolucoesPaginadas;
            ViewBag.TotalRegistros = devolucoesPaginadas.TotalItemCount;

            return View(_pesquisaDevolucaoViewModel);
        }

        // GET: Devolucao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Devolucao/Create
        public ActionResult Create()
        {
            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", string.Empty);

            ViewBag.DataDevolucao = DateTime.Now.ToShortDateString();

            return View();
        }

        // POST: Devolucao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Devolucao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Devolucao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Devolucao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Devolucao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PesquisarProdutosDevolucao()
        {
            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();

            var produtoViewModel = _produtoApp.ObtemPorFiltroQuantidadeDisponivel(1, 6);

            _pesquisaProdutoViewModel.Produtos = produtoViewModel;

            _pesquisaProdutoViewModel.ListaProdutos = this.MontaListaProdutos(_pesquisaProdutoViewModel.Produtos);

            return PartialView("~/Views/Produtos/PartialPesquisaProdutosDevolucao.cshtml", _pesquisaProdutoViewModel);
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

        [HttpPost]
        public JsonResult GravarDevolucao(string pDataDevolucao, string pVendedor, List<ProdutoSelecionado> ProdutoSelecionado)
        {
            gUsuario = GetUsuarioLogado();
            Devolucao lDevolucao = new Devolucao();
            List<DevolucaoProduto> lListaDevolucaoProduto = new List<DevolucaoProduto>();
            decimal lQtdProdutoVendida = 0;
            string result = string.Empty;

            foreach (var item in ProdutoSelecionado)
            {
                DevolucaoProduto lDevolucaoProduto = new DevolucaoProduto();
                lDevolucaoProduto.IdProduto = item.IdProduto;
                lDevolucaoProduto.QtdDevolvida = item.QuantidadeVendida;

                lQtdProdutoVendida += item.QuantidadeVendida;

                lListaDevolucaoProduto.Add(lDevolucaoProduto);
            }

            lDevolucao.IdUsuario = gUsuario.IdVendedor;
            lDevolucao.IdVendedor = int.Parse(pVendedor);
            lDevolucao.DataDevolucao = Convert.ToDateTime(pDataDevolucao).Date;
            lDevolucao.DataModificacao = DateTime.Now.Date;
            
            lDevolucao.DevolucaoProduto = lListaDevolucaoProduto;

            _devolucaoAppService.GravarDevolucao(lDevolucao);

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

       
        public JsonResult GerarRelatorio(DevolucaoViewModel pDevolucao)
        {
            _relatorioApp.RelatorioDevolucao(Response, pDevolucao);

            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        public void GerarRelatorioLeave(string DataDevolucao, string Produto, string Vendedor)
        {
            ////////_relatorioApp.RelatorioDevolucao(Response, pDevolucao);
            string teste = "";
        }

        public ActionResult PesquisarDevolucoesHoje()
        {
            DevolucaoViewModel _pesquisaDevolucaoViewModel = new DevolucaoViewModel();

            Devolucao lDevolucao = new Devolucao();
            lDevolucao.DataDevolucao = DateTime.Now.Date;

            var devolucoes = _devolucaoAppService.ObtemDevolucoesPorFiltroOrdenado(lDevolucao);
            var devolucoesPaginadas = (PagedList<Devolucao>)devolucoes.ToPagedList(1, 100);

            _pesquisaDevolucaoViewModel.DevolucaoPaginada = devolucoesPaginadas;
            ViewBag.TotalRegistros = devolucoesPaginadas.TotalItemCount;

            return PartialView("~/Views/Devolucao/PartialDevolucoesHoje.cshtml", _pesquisaDevolucaoViewModel);
        }
    }
}
