
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}