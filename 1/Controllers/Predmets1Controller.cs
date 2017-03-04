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
    public class Predmets1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Predmets1
        public ActionResult Index()
        {
            List<Predmet> predmeti = null;

            if (User.IsInRole(Role.STUDENT))
            {
                //Student s = null;
                //foreach (Student x in db.Students)
                //{
                //    if (x.Email == User.Identity.Name)
                //    {
                //        s = x;
                //        break;
                //    }
                //}

                //1. nadjemo studenta
                Student student = db.Students.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
                ViewBag.StudentId = student.Id;

                //2. nadjemo predmete
                predmeti = db.Predmeti.Where(x => x.GodinaStudija <= student.GodinaStudija).ToList();
            }
            else// if (User.IsInRole(Role.ADMIN))
            {
                predmeti = db.Predmeti.ToList();
            }

            return View(predmeti);
        }

        // GET: Predmets1/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(Id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // GET: Predmets1/Create
        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmets1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ime,Semestar,Profesor,GodinaStudija")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Predmeti.Add(predmet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predmet);
        }

        // GET: Predmets1/Edit/5
        public ActionResult Prijavi(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(Id);
            //1. nadjemo studenta
            Student student = db.Students.Where(x => x.Email == User.Identity.Name).FirstOrDefault();

            if (predmet == null || student == null)
            {
                return HttpNotFound();
            }

            //prijavio
            student.Statusi.Add(new Status_Predmeta()
            {
                Prijavljen = true,
                Student = student,
                Predmet = predmet
            });

            db.SaveChanges();


            return RedirectToAction("Index");
        }

        // GET: Predmets1/Edit/5
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(Id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmets1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Semestar,Profesor")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predmet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predmet);
        }

        // GET: Predmets1/Delete/5
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmeti.Find(Id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmets1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? Id)
        {
            Predmet predmet = db.Predmeti.Find(Id);
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
