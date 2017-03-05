using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1.Models;

namespace _1.Controllers
{
    [Authorize]
    public class Status_PredmetaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Status_Predmeta
        public ActionResult Index()
        {
            //return View(db.Status.ToList());
            List<Status_Predmeta> SP = new List<Status_Predmeta>();

            if (User.IsInRole(Role.ADMIN))
            {
                Administrator admin = db.Administrators.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
                ViewBag.StudentId = admin.Id;

                SP = db.Status.ToList();

            }
            return View(SP);
        }

        // GET: Status_Predmeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Predmeta status_Predmeta = db.Status.Find(id);
            if (status_Predmeta == null)
            {
                return HttpNotFound();
            }
            return View(status_Predmeta);
        }

        // GET: Status_Predmeta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status_Predmeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Polozen,Prijavljen")] Status_Predmeta status_Predmeta)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status_Predmeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_Predmeta);
        }

        // GET: Status_Predmeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Predmeta status_Predmeta = db.Status.Find(id);
            if (status_Predmeta == null)
            {
                return HttpNotFound();
            }
            return View(status_Predmeta);
        }

        // POST: Status_Predmeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Polozen,Prijavljen")] Status_Predmeta status_Predmeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_Predmeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_Predmeta);
        }

        // GET: Status_Predmeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Predmeta status_Predmeta = db.Status.Find(id);
            if (status_Predmeta == null)
            {
                return HttpNotFound();
            }
            return View(status_Predmeta);
        }

        // POST: Status_Predmeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status_Predmeta status_Predmeta = db.Status.Find(id);
            db.Status.Remove(status_Predmeta);
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
