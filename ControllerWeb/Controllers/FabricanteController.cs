using Application.Interfaces;
using ControllerWeb.ViewModels;
using Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerWeb.Controllers
{
    public class FabricanteController : Controller
    {
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloFabricanteAppService _modeloFabricanteApp;
        private readonly IModeloAppService _modeloApp;

        public FabricanteController(IFabricanteAppService fabricanteApp, IModeloFabricanteAppService modeloFabricanteApp, IModeloAppService modeloApp)
        {
            _fabricanteApp = fabricanteApp;
            _modeloFabricanteApp = modeloFabricanteApp;
            _modeloApp = modeloApp;
        }
        // GET: Fabricante
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);

            var fabricantes = _fabricanteApp.ObtemTodos();
            var fabricantesPaginados = (PagedList<Fabricante>)fabricantes.ToPagedList(pageNumber, 10);

            FabricanteViewModel lFabricanteViewModel = new FabricanteViewModel();

            lFabricanteViewModel.FabricantesPaginados = fabricantesPaginados;

            ViewBag.TotalRegistros = lFabricanteViewModel.FabricantesPaginados.TotalItemCount;

            return View(lFabricanteViewModel);
        }

        // GET: Fabricante/Details/5
        public ActionResult Details(int id)
        {
            var lFabricante = _fabricanteApp.ObtemPorId(id);

            return View(lFabricante);
        }

        // GET: Fabricante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabricante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante pFabricante)
        {
            if (ModelState.IsValid)
            {
                var lFabricante = pFabricante;

                _fabricanteApp.Add(lFabricante);

                return RedirectToAction("Index");
            }

            return View(pFabricante);
        }

        // GET: Fabricante/Edit/5
        public ActionResult Edit(int id)
        {
            var lPerfil = _fabricanteApp.ObtemPorId(id);

            return View(lPerfil);
        }

        // POST: Fabricante/Edit/5
        [HttpPost]
        public ActionResult Edit(Fabricante pFabricante)
        {
            if (ModelState.IsValid)
            {
                _fabricanteApp.Update(pFabricante);

                return RedirectToAction("Index");
            }
            return View(pFabricante);
        }

        // GET: Fabricante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fabricante/Delete/5
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
    }
}
