using System.Linq;
using System.Web.Mvc;
using WebApiRebelsRegistration.Models;
using WebApiRebelsRegistration.Models.Repositories;

namespace WebApiRebelsRegistration.Controllers
{
    public class RebeldsController : Controller
    {
        private readonly IRepositoryRebelds Repository = new RepositoryRebelds();

        // GET: Rebelds
        public ActionResult Index()
        {
            return View(Repository.GetAllRebelds().ToList());
        }

        // GET: Rebelds/Details/5
        public ActionResult Details(int id)
        {
            Rebelds rebelds = Repository.GetRebeld(id);
            if (rebelds == null)
            {
                return HttpNotFound();
            }
            return View(rebelds);
        }

        // GET: Rebelds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rebelds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Rebelds rebelds)
        {
            if (ModelState.IsValid)
            {
                Repository.AddRebeld(rebelds);
                return RedirectToAction("Index");
            }

            return View(rebelds);
        }

        // GET: Rebelds/Edit/5
        public ActionResult Edit(int id)
        {
            Rebelds rebelds = Repository.GetRebeld(id);
            if (rebelds == null)
            {
                return HttpNotFound();
            }
            return View(rebelds);
        }

        // POST: Rebelds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Rebelds rebelds)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateRebeld(rebelds);
                return RedirectToAction("Index");
            }
            return View(rebelds);
        }

        // GET: Rebelds/Delete/5
        public ActionResult Delete(int id)
        {
            Rebelds rebelds = Repository.GetRebeld(id);
            if (rebelds == null)
            {
                return HttpNotFound();
            }
            return View(rebelds);
        }

        // POST: Rebelds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rebelds rebelds = Repository.GetRebeld(id);
            Repository.DeleteRebeld(rebelds);
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
