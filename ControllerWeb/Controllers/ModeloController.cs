using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControllerWeb.Controllers
{
    public class ModeloController : BaseController
    {
        private readonly IModeloAppService _modeloApp;
        private readonly IFabricanteAppService _fabricanteApp;
        private readonly IModeloFabricanteAppService _modeloFabricanteApp;

        public ModeloController(IModeloAppService modeloApp, IFabricanteAppService fabricanteApp, IModeloFabricanteAppService modeloFabricanteApp)
        {
            this._modeloApp = modeloApp;
            this._fabricanteApp = fabricanteApp;
            this._modeloFabricanteApp = modeloFabricanteApp;
        }

        // GET: Modelo
        public ActionResult Index()
        {
            var lModelo = _modeloApp.ObtemTodos();
            return View(lModelo);
        }

        // GET: Modelo/Details/5
        public ActionResult Details(int id)
        {
            var lModelo = _modeloApp.ObtemPorId(id);

            return View(lModelo);
        }

        // GET: Modelo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modelo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelo pModelo)
        {
            if (ModelState.IsValid)
            {
                _modeloApp.Add(pModelo);

                return RedirectToAction("Index");
            }

            return View(pModelo);
        }

        // GET: Modelo/Edit/5
        public ActionResult Edit(int id)
        {
            var lModelo = _modeloApp.ObtemPorId(id);

            return View(lModelo);
        }

        // POST: Modelo/Edit/5
        [HttpPost]
        public ActionResult Edit(Modelo pModelo)
        {
            if (ModelState.IsValid)
            {
                var lModelo = pModelo;
                _modeloApp.Update(lModelo);

                return RedirectToAction("Index");
            }

            return View(pModelo);
        }

        // GET: Modelo/Delete/5
        public ActionResult Delete(int id)
        {
            var lModelo = _modeloApp.ObtemPorId(id);

            return View(lModelo);
        }

        // POST: Modelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lModelo = _modeloApp.ObtemPorId(id);
            _modeloApp.Remove(lModelo);

            return RedirectToAction("Index");
        }
    }
}
