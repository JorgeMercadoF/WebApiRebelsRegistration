using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApiRebelsRegistration.Models;
using WebApiRebelsRegistration.Models.Repositories;

namespace WebApiRebelsRegistration.Controllers
{
    public class RegisterRebeldsController : Controller
    {
        private JorgeMercadoEntities db = new JorgeMercadoEntities();
        private readonly IRepositoryRegisterRebelds Repository = new RepositoryRegisterRebelds();

        // GET: RegisterRebelds
        public ActionResult Index()
        {

            var registerRebelds = db.RegisterRebelds.Include(r => r.Planets).Include(r => r.Rebelds);
            return View(registerRebelds.ToList());

            /*
            return View(Repository.GetAllRegsiter().ToList());
            */
        }

        // GET: RegisterRebelds/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterRebelds registerRebelds = db.RegisterRebelds.Find(id);
            if (registerRebelds == null)
            {
                return HttpNotFound();
            }
            return View(registerRebelds);


            /*
            RegisterRebelds register = Repository.GetRegister(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
            */
        }

        // GET: RegisterRebelds/Create
        public ActionResult Create()
        {
            ViewBag.IdPlanet = new SelectList(db.Planets, "Id", "Name");
            ViewBag.IdRebeld = new SelectList(db.Rebelds, "Id", "Name");
            return View();
        }

        // POST: RegisterRebelds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdRebeld,IdPlanet,DateRegsiter")] RegisterRebelds registerRebelds)
        {
            if (ModelState.IsValid)
            {
                db.RegisterRebelds.Add(registerRebelds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPlanet = new SelectList(db.Planets, "Id", "Name", registerRebelds.IdPlanet);
            ViewBag.IdRebeld = new SelectList(db.Rebelds, "Id", "Name", registerRebelds.IdRebeld);
            return View(registerRebelds);
        }

        // GET: RegisterRebelds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterRebelds registerRebelds = db.RegisterRebelds.Find(id);
            if (registerRebelds == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPlanet = new SelectList(db.Planets, "Id", "Name", registerRebelds.IdPlanet);
            ViewBag.IdRebeld = new SelectList(db.Rebelds, "Id", "Name", registerRebelds.IdRebeld);
            return View(registerRebelds);
        }

        // POST: RegisterRebelds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdRebeld,IdPlanet,DateRegsiter")] RegisterRebelds registerRebelds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerRebelds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPlanet = new SelectList(db.Planets, "Id", "Name", registerRebelds.IdPlanet);
            ViewBag.IdRebeld = new SelectList(db.Rebelds, "Id", "Name", registerRebelds.IdRebeld);
            return View(registerRebelds);
        }

        // GET: RegisterRebelds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterRebelds registerRebelds = db.RegisterRebelds.Find(id);
            if (registerRebelds == null)
            {
                return HttpNotFound();
            }
            return View(registerRebelds);
        }

        // POST: RegisterRebelds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterRebelds registerRebelds = db.RegisterRebelds.Find(id);
            db.RegisterRebelds.Remove(registerRebelds);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
