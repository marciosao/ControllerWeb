using Application.Interfaces;
using Domain.Entities;
//using ControllerWeb.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;


namespace ControllerWeb.Controllers
{
    public class VendedorController : BaseController
    {
        private readonly IVendedorAppService _vendedorApp;
        private readonly IPerfilAppService _PerfilApp;

        public VendedorController(IVendedorAppService vendedorApp, IPerfilAppService PerfilApp)
        {
            this._vendedorApp = vendedorApp;
            this._PerfilApp = PerfilApp;
        }

        // GET: vendedors
        public ActionResult Index()
        {
            var lVendedorViewModel = _vendedorApp.ObtemTodos();
            ViewBag.IdPerfil = new SelectList(_PerfilApp.ObtemTodos(), "IdPerfil", "Nome",0);
            return View(lVendedorViewModel);
        }

        // GET: vendedors/Details/5
        public ActionResult Details(int id)
        {
            var lvendedor = _vendedorApp.ObtemPorId(id);
            ViewBag.IdPerfil = new SelectList(_PerfilApp.ObtemTodos(), "IdPerfil", "Nome", 0);
            return View(lvendedor);
        }

        // GET: vendedors/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(_PerfilApp.ObtemTodos(), "IdPerfil", "Nome", 0);
            return View();
        }

        // POST: vendedors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendedor pvendedor)
        {
            if (ModelState.IsValid)
            {
                var lvendedorDomain =pvendedor;
                ViewBag.IdPerfil = new SelectList(_PerfilApp.ObtemTodos(), "IdPerfil", "Nome", 0);

                _vendedorApp.Add(lvendedorDomain);

                return RedirectToAction("Index");
            }

            return View(pvendedor);
        }

        // GET: vendedors/Edit/5
        public ActionResult Edit(int id)
        {
            var lvendedor = _vendedorApp.ObtemPorId(id);

            ViewBag.IdPerfil = new SelectList(_PerfilApp.ObtemTodos(), "IdPerfil", "Nome", lvendedor.IdPerfil);
            return View(lvendedor);
        }

        // POST: vendedors/Edit/5
        [HttpPost]
        public ActionResult Edit(Vendedor pVendedorViewModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IdPerfil = new SelectList(_PerfilApp.ObtemTodos(), "IdPerfil", "Nome");
                var lvendedor = pVendedorViewModel;
                _vendedorApp.Update(lvendedor);

                return RedirectToAction("Index");
            }
            return View(pVendedorViewModel);
        }

        // GET: vendedors/Delete/5
        public ActionResult Delete(int id)
        {
            var lvendedor = _vendedorApp.ObtemPorId(id);
            
            return View(lvendedor);
        }

        // POST: vendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lvendedor = _vendedorApp.ObtemPorId(id);
            _vendedorApp.Remove(lvendedor);

            return RedirectToAction("Index");
        }
    }
}
