
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1.Models;

namespace _1.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string predmetId, int studentId)
        {

            var student = db.Students.Find(studentId);
            var predmet = db.Predmeti.Find(predmetId);

            //polozio
            student.Statusi.Add(new Status_Predmeta()
            {
                Polozen = true,
                Student = student,
                Predmet = predmet
            });

            db.SaveChanges();

            ViewBag.Message = string.Join(",", student.Statusi.Select(x => x.Predmet.Ime));

            return View();
        }
        //[Route("FreeWebProgrammingCourse/{year:int}/{category:length(1,8)}", Order=2)]
        //[Route("FreeProgrammingCourse/{year:int}/{category?}", Order = 1)]
        [Route("AttributeRouteTest/{year:int}")]
        public ActionResult AttributeRouteTest(int year, string category)
        {
            return Content(string.Format("{0}/{1}", year, category));
        }

        public ActionResult TestAction()
        {
            ViewBag.Person = new Models.Student() { Name="Ivan" };
            ViewData["Message"] = "From Controller";
            ViewData["Person"] = new Models.Student() { Name = "Ivan1" };

            return View();
        }
        
        public ActionResult FileResult()
        {
            return File(Server.MapPath("~/Content/Images/logo.jpg"), MimeMapping.GetMimeMapping("logo.jpg"));
        }

        public ActionResult DownloadFileResult()
        {
            var filename = "logo.jpg";
            return File(Server.MapPath("~/Content/Images/" + filename), MimeMapping.GetMimeMapping(filename), filename);
        }
       
        public ActionResult Edit()
        {
            ViewBag.Message = "Your contact page.";

        
            return View();
        }
    }
}