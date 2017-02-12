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
    public class PredmetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Predmets
        public ActionResult Index()
        {
            return View(db.Predmeti.ToList());
        }

        // GET: Predmets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // GET: Predmets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ime,Semestar,Profesor,Smer")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Predmeti.Add(predmet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predmet);
        }

        // GET: Predmets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ime,Semestar,Profesor,Smer")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predmet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predmet);
        }

        // GET: Predmets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Predmet predmet = db.Predmeti.Find(id);
            db.Predmeti.Remove(predmet);
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
