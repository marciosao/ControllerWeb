using Application.Interfaces;
using Domain.Entities;
//using ControllerWeb.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;


namespace ControllerWeb.Controllers
{
    public class PerfilController : BaseController
    {
        private readonly IPerfilAppService _perfilApp;

        public PerfilController(IPerfilAppService perfilApp)
        {
            this._perfilApp = perfilApp;
        }

        // GET: Perfil
        public ActionResult Index()
        {
            var lPerfil = _perfilApp.ObtemTodos();

            return View(lPerfil);

        }

        // GET: Perfil/Details/5
        public ActionResult Details(int id)
        {
            var lPerfil = _perfilApp.ObtemPorId(id);

            return View(lPerfil);
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfil/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Perfil pPerfil)
        {
            if (ModelState.IsValid)
            {
                var lPerfil = pPerfil;

                _perfilApp.Add(lPerfil);

                return RedirectToAction("Index");
            }

            return View(pPerfil);
        }

        // GET: Perfil/Edit/5
        public ActionResult Edit(int id)
        {
            var lPerfil = _perfilApp.ObtemPorId(id);

            return View(lPerfil);
        }

        // POST: Perfil/Edit/5
        [HttpPost]
        public ActionResult Edit(Perfil pPerfil)
        {
            if (ModelState.IsValid)
            {
                _perfilApp.Update(pPerfil);

                return RedirectToAction("Index");
            }
            return View(pPerfil);
        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int id)
        {
            var lPerfil = _perfilApp.ObtemPorId(id);

            return View(lPerfil);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lPerfil = _perfilApp.ObtemPorId(id);
            _perfilApp.Remove(lPerfil);

            return RedirectToAction("Index");
        }
    }
}
