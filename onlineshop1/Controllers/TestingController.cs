using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineshop1.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ViewResult ShowSum()
        {
            int[] data = { 3, 45, 43, 3, 23 };
            //int c = int.Parse(data);
            ViewData["s"] = "the sum is " + data.Sum();
            return View();
        }

        [HttpGet]// run this method for first request
        public ViewResult AcceptNPrint()
        {
            return View();
        }
        [HttpPost]// run this method only on submit
        public ViewResult AcceptNPrint(string t1,string t2)
        {
            int c = int.Parse(t1);
            ViewData["v"] = t1;
            //ViewData["t"] = t2;
          
            return View();
        }

    }
}