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
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            List<Student> studenti = new List<Student>();

            if (User.IsInRole(Role.STUDENT))
            {
                Student student = db.Students.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
                ViewBag.StudentId = student.Id;

                studenti.Add(student);

            }
            else
            {
                studenti = db.Students.ToList();

            }

            return View(studenti);
        }

        // GET: Students/Details/5
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Email,Prezime,GodinaStudija,PolType")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Prezime,GodinaStudija,PolType")] Student viewStudent)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;

                Student dbStudent = db.Students.Find(viewStudent.Id);

                dbStudent.Name = viewStudent.Name;
                dbStudent.GodinaStudija = viewStudent.GodinaStudija;
                dbStudent.Prezime = viewStudent.Prezime;
                dbStudent.PolType = viewStudent.PolType;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
                
                return RedirectToAction("Index");
            }

            return View(viewStudent);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
