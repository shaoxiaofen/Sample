using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var siteinfo = new Websiteinfo("Demo", "RIGHI");
            ViewBag.siteInfo = siteinfo;

            ViewData["SiteInfo"] = siteinfo;
                   

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application descripition page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page;";

            return View();
        }
    }
}
