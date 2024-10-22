using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace onlineshop1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            string[] names = { "siri", "giri", "maitri", "anki", "chintu", "chiti" };
            ViewBag.d2 = names;
            ViewData["d1"] = names;
            //string st = "cool page......!";
            //ViewData["a"] = st;
            //ViewData["b"] = "hello student";
            //ViewData["m"] = 100;
            //ViewData["n"] = 400;
            //ViewBag.hi = "Welcome to mvc world!";
            //ViewBag.p = 100;
            //ViewBag.q = 200;
            //TempData["t"] = "simpole temp data";
            //TempData.Keep("t");
            //return View();
            // return "<font color=red><b><Hello world!<b></font>";
            return View();
        }
        public ViewResult Mphasis()
        {

            return View();
        }
        public ViewResult cs()
        {
            return View();
        }
        //public ViewResult Gretatest()
        //{
        //    ViewBag.d1 =t1;
        //    ViewBag.d2 = t2;
        //    if ((ViewBag.d1)>(ViewBag.d2))
        //    {

        //    }
        //    return View();
        //}
        [HttpGet]// run this method for first request
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]// run this method only on submit
        public ViewResult Add(string t1, string t2)
        {
            int c = int.Parse(t1) + int.Parse(t2);
            ViewData["r"] = "the sum is " + c;
            return View();
        }

        
    }
}