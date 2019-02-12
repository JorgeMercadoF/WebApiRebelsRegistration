using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiRebelsRegistration.Models;
using WebApiRebelsRegistration.Models.Repositories;

namespace WebApiRebelsRegistration.Controllers
{
    public class PlanetsController : Controller
    {
        private readonly IRepositoryPlanets Repository = new RepositoryPlanets();

        // GET: Planets
        public ActionResult Index()
        {
            return View(Repository.GetAllPlanets().ToList());
        }

        // GET: Planets/Details/5
        public ActionResult Details(int id)
        {
            Planets planets = Repository.GetPlanet(id);
            if (planets == null)
            {
                return HttpNotFound();
            }
            return View(planets);
        }

        // GET: Planets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Planets planets)
        {
            if (ModelState.IsValid)
            {
                Repository.AddPlanet(planets);
                return RedirectToAction("Index");
            }

            return View(planets);
        }

        // GET: Planets/Edit/5
        public ActionResult Edit(int id)
        {
            Planets planets = Repository.GetPlanet(id);
            if (planets == null)
            {
                return HttpNotFound();
            }
            return View(planets);
        }

        // POST: Planets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Planets planets)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdatePlanet(planets);
                return RedirectToAction("Index");
            }
            return View(planets);
        }

        // GET: Planets/Delete/5
        public ActionResult Delete(int id)
        {
            Planets planets = Repository.GetPlanet(id);
            if (planets == null)
            {
                return HttpNotFound();
            }
            return View(planets);
        }

        // POST: Planets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planets planets = Repository.GetPlanet(id);
            Repository.DeletePlanet(planets);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
