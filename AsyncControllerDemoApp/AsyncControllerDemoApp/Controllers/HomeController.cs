using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace AsyncControllerDemoApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            DateTime dt1 = DateTime.Now;
            Task<int> t1 = Operation(1000);
            Task<int> t2 = Operation(1000);
            Task<int> t3 = Operation(1000);

            await Task.WhenAll(t1, t2, t3);
            int op1 = await t1;
            int op2 = await t2;
            int op3 = await t3;

            int result = op1 + op2 + op3;
            DateTime dt2 = DateTime.Now;
            ViewBag.TotalTime = (dt2 - dt1).ToString();

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<int> Operation(int timeInMilliseconds)
        {
            await Task.Run(() =>
            { System.Threading.Thread.Sleep(timeInMilliseconds); });
            
            return 1;
        }
    }
}