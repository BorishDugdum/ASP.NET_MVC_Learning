using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilters.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration =10)] //cache an output (will ignore subsequent requests within 10 seconds)
        public ActionResult Index()
        {
            ViewBag.SysTime = DateTime.Now.ToLongTimeString();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //turn on/off validation for tag submissions (scripts/etc)
        [ValidateAntiForgeryToken()] //prevent cross-site forgery
        public ActionResult Index(string txtDemo)
        {
            ViewBag.Demo = txtDemo;
            return View();
        }

        //[Authorize] //restrict action/controller to authorized user/role
        //[HandleError] //sends errors to Error.cshtml - implemented in Web.config (customErrors)
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            throw new ApplicationException("Error!");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}