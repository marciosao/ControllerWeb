using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using ControllerWeb.ViewModels;
using System;
using PagedList;
using ControllerWeb.Util;
using System.Text;

namespace ControllerWeb.Controllers
{
    public class VendasController : BaseController
    {
        private readonly IVendaAppService _vendaApp;
        private readonly IVendedorAppService _vendedorApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloAppService _modeloApp;
        private readonly RelatorioAppService _relatorioApp;
        private readonly ILogSistemaAppService _logSistemaApp;

        public VendasController(IVendaAppService vendaApp, IVendedorAppService vendedorApp, IProdutoAppService produtoApp, IFabricanteAppService fabricanteApp, IModeloAppService modeloApp, RelatorioAppService relatorioApp,ILogSistemaAppService logSistemaApp)
        {
            this._vendaApp = vendaApp;
            this._vendedorApp = vendedorApp;
            this._produtoApp = produtoApp;
            this._fabricanteApp = fabricanteApp;
            this._modeloApp = modeloApp;
            this._relatorioApp = relatorioApp;
            this._logSistemaApp = logSistemaApp;
        }

        // GET: Vendas
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);

            PesquisaVendasViewModel _pesquisaVendasViewModel = new PesquisaVendasViewModel();

            try
            {
                ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", "Grilberto");


                var vendasViewModel = _vendaApp.ObtemVendasOrdenado();
                var VendasPaginadas = (PagedList<Venda>)vendasViewModel.ToPagedList(pageNumber, 10);

                _pesquisaVendasViewModel.VendasPaginadas = VendasPaginadas;

                ViewBag.TotalRegistros = VendasPaginadas.TotalItemCount;
            }
            catch (Exception ex)
            {
                LogSistema lLog = new LogSistema();
                lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
                lLog.Tela = "Venda";
                lLog.Acao = "Index1";
                lLog.DataOcorrencia = DateTime.Now;
                if (GetUsuarioLogado() != null)
                {
                    lLog.Usuario = GetUsuarioLogado().IdVendedor;
                }
                _logSistemaApp.Add(lLog);
            }

            return View(_pesquisaVendasViewModel);
        }

        [HttpPost]
        public ActionResult Index(PesquisaVendasViewModel pVendaFiltros, int? page)
        {
            int pageNumber = (page ?? 1);

            PesquisaVendasViewModel _pesquisaVendasViewModel = new PesquisaVendasViewModel();

            try
            {
                ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome", "Gilberto");

                Venda lVenda = new Venda();

                if (pVendaFiltros.DataVenda != null && !pVendaFiltros.DataVenda.Date.ToShortDateString().Equals("01/01/0001"))
                {
                    lVenda.DataVenda = pVendaFiltros.DataVenda;
                }
                if (!string.IsNullOrEmpty(pVendaFiltros.Codigo))
                {

                    lVenda.Codigo = pVendaFiltros.Codigo;
                }
                if (pVendaFiltros.IdVendedor > 0)
                {
                    lVenda.IdVendedor = pVendaFiltros.IdVendedor;
                }

                var vendasViewModel = _vendaApp.ObtemPorFiltro(lVenda);

                var VendasPaginadas = (PagedList<Venda>)vendasViewModel.ToPagedList(pageNumber, 10);

                _pesquisaVendasViewModel.VendasPaginadas = VendasPaginadas;

                ViewBag.TotalRegistros = VendasPaginadas.TotalItemCount;
            }
            catch (Exception ex)
            {
                LogSistema lLog = new LogSistema();
                lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
                lLog.Tela = "Venda";
                lLog.Acao = "Index2";
                lLog.DataOcorrencia = DateTime.Now;
                if (GetUsuarioLogado() != null)
                {
                    lLog.Usuario = GetUsuarioLogado().IdVendedor;
                }
                _logSistemaApp.Add(lLog);
            }

            return View(_pesquisaVendasViewModel);
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int id)
        {
            var lVenda = _vendaApp.ObtemPorId(id);

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "Id", "Nome");

            return View(lVenda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "IdVendedor", "Nome");

                ViewBag.DataVenda = DateTime.Now.ToShortDateString();

                ViewBag.MsgErro = ViewBag.MsgErro;

                ViewBag.MsgSucesso = ViewBag.MsgSucesso;
            }
            catch (Exception ex)
            {
                LogSistema lLog = new LogSistema();
                lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
                lLog.Tela = "Venda";
                lLog.Acao = "Create";
                lLog.DataOcorrencia = DateTime.Now;
                if (GetUsuarioLogado() != null)
                {
                    lLog.Usuario = GetUsuarioLogado().IdVendedor;
                }
                _logSistemaApp.Add(lLog);
            }
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel pVenda)
        {
            Venda lVenda = new Venda();

            if (ModelState.IsValid)
            {
                _vendaApp.Add(lVenda);

                return RedirectToAction("Index");
            }

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "Id", "Nome");

            return View(pVenda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int id)
        {
            var lVenda = _vendaApp.ObtemPorId(id);

            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "Id", "Nome");

            return View(lVenda);
        }

        // POST: Vendas/Edit/5
        [HttpPost]
        public ActionResult Edit(Venda pVenda)
        {
            if (ModelState.IsValid)
            {
                pVenda.DataModificacao = DateTime.Now;
                var lVenda = pVenda;
                _vendaApp.Update(lVenda);

                return RedirectToAction("Index");
            }
            ViewBag.IdVendedor = new SelectList(_vendedorApp.ObtemTodos(), "Id", "Nome");

            return View(pVenda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int id)
        {
            var lVenda = _vendaApp.ObtemPorId(id);

            return View(lVenda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lVenda = _vendaApp.ObtemPorId(id);
            _vendaApp.Remove(lVenda);

            return RedirectToAction("Index");
        }

        public ActionResult PesquisarProdutosVenda()
        {
            PesquisaProdutoViewModel _pesquisaProdutoViewModel = new PesquisaProdutoViewModel();

            var produtoViewModel = _produtoApp.ObtemPorFiltroQuantidadeDisponivel(1, 6);

            _pesquisaProdutoViewModel.Produtos = produtoViewModel;

            _pesquisaProdutoViewModel.ListaProdutos = this.MontaListaProdutos(_pesquisaProdutoViewModel.Produtos);

            return PartialView("~/Views/Produtos/PartialPesquisaProdutos.cshtml", _pesquisaProdutoViewModel);
        }

        [HttpPost]
        public JsonResult ObtemFabricantePorCodigo(string pCodigo)
        {
            Produto lProdutos = new Produto();
            PesquisaProdutoViewModel lProdutoViewModel = new PesquisaProdutoViewModel();
            lProdutos.Codigo = pCodigo;

            lProdutoViewModel.Produtos = _produtoApp.ObtemPorFiltroQuantidadeDisponivel(lProdutos, 1, 10);

            lProdutoViewModel.ListaProdutos = this.MontaListaProdutos(lProdutoViewModel.Produtos);

            return Json(lProdutoViewModel.ListaProdutos, JsonRequestBehavior.AllowGet);
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
        public JsonResult GravarVenda(string pCodigo, string pDataVenda, string pVendedor, List<ProdutoSelecionado> ProdutoSelecionado)
        {
            Venda lVenda = new Venda();
            List<VendasProduto> lListaVendasProduto = new List<VendasProduto>();
            decimal lQtdProdutoVendida = 0;
            StringBuilder lMensagemErro = new StringBuilder();
            string result = string.Empty;

            try
            {
                foreach (var item in ProdutoSelecionado)
                {
                    Produto lProduto = _produtoApp.ObtemPorId(item.IdProduto);

                    if (lProduto.QtdEstoque >= item.QuantidadeVendida)
                    {
                        VendasProduto lVendasProduto = new VendasProduto();
                        lVendasProduto.IdProduto = item.IdProduto;
                        lVendasProduto.QtdVendida = item.QuantidadeVendida;

                        lQtdProdutoVendida += item.QuantidadeVendida;

                        lListaVendasProduto.Add(lVendasProduto);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(result))
                        {
                            result += "O(s) Produto(s) de código(s): \n";
                            result += " " + lProduto.Codigo + " \n";
                        }
                        else
                        {
                            result += " " + lProduto.Codigo + " \n";
                        }
                    }
                }

                if (string.IsNullOrEmpty(result))
                {
                    gUsuario = GetUsuarioLogado();

                    lVenda.Codigo = pCodigo;
                    lVenda.IdUsuario = gUsuario.IdVendedor.ToString();
                    lVenda.IdVendedor = int.Parse(pVendedor);
                    lVenda.DataVenda = Convert.ToDateTime(pDataVenda);
                    lVenda.DataModificacao = DateTime.Now.Date;
                    lVenda.QtdVendida = lQtdProdutoVendida;

                    lVenda.VendasProduto = lListaVendasProduto;

                    _vendaApp.GravarVenda(lVenda);

                    result = "ok";
                }
                else
                {
                    result += " não tem quantidade suficente no estoque para ser vendido. \n";
                    result += " A VENDA NÃO FOI CADASTRADA";
                }
            }
            catch (Exception ex)
            {
                LogSistema lLog = new LogSistema();
                lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
                lLog.Tela = "Venda";
                lLog.Acao = "JsonResult GravarVenda";
                lLog.DataOcorrencia = DateTime.Now;
                if (GetUsuarioLogado() != null)
                {
                    lLog.Usuario = GetUsuarioLogado().IdVendedor;
                }
                _logSistemaApp.Add(lLog);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GerarRelatorio(PesquisaVendasViewModel pVenda)
        {
            _relatorioApp.RelatorioVendas(Response, pVenda);

            return View();
        }

        [ChildActionOnly]
        public ActionResult PartialModalRedirect()
        {
            if (Session["EntityStateRedir"] != null)
            {
                switch (Session["EntityStateRedir"].ToString())
                {
                    case "Success":
                        ViewBag.TituloModal = "Mensagem do Sistema";
                        ViewBag.MensagemModal = Session["sModalErroRedir"].ToString();
                        break;
                    default:
                        ViewBag.MensagemModal = Session["sModalErroRedir"].ToString();
                        ViewBag.TituloModal = "Mensagem do Sistema";
                        break;
                }
            }

            Session["EntityStateRedir"] = null;
            Session["sModalErroRedir"] = null;
            ViewBag.successRedir = "Index";
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult PartialModalConfirmLogin()
        {
            string caminho = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            ViewBag.Caminho = caminho;
            ViewBag.MensagemModal = Session["sModalMsgm"].ToString();
            ViewBag.TituloModal = Session["sModalTit"].ToString();
            ViewBag.MsgErro = Session["sMsgErro"];

            Session["sModalMsgm"] = null;
            Session["sModalTit"] = null;
            Session["sMsgErro"] = null;
            Session["FlagBotoesTela"] = null;

            return PartialView();
        }

        public ActionResult PesquisarVendasHoje()
        {
            PesquisaVendasViewModel _pesquisaVendasViewModel = new PesquisaVendasViewModel();

            Venda lVenda = new Venda();

            lVenda.DataVenda = DateTime.Now.Date;

            var vendasViewModel = _vendaApp.ObtemPorFiltro(lVenda);

            var VendasPaginadas = (PagedList<Venda>)vendasViewModel.ToPagedList(1, 100);

            _pesquisaVendasViewModel.VendasPaginadas = VendasPaginadas;

            return PartialView("~/Views/Vendas/PartialVendasHoje.cshtml", _pesquisaVendasViewModel);
        }
    }
}
