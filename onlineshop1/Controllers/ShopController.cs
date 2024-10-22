using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlineshop1.Models;
namespace onlineshop1.Controllers
{
    public class ShopController : Controller
    {
       onlineshoppingdbEntities dc= new onlineshoppingdbEntities();
        
        public ViewResult Home()
            //every method represts a login page
        {
            return View();
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        // ActionResult: method can return anything like
        // content ,via, 
        [HttpPost]
        public ActionResult Login(string t1, string t2)
        {
            var res = (from t in dc.Registertbls
                       where t.uname == t1 && t.password == t2
                       select t).Count();
            if (res > 0)
            {
                Session["uid"] = t1;
                // code to navigate
                return RedirectToAction("Products");
            }
            else
            {
                ViewData["err"] = "Invalid Usernamr or password";
            }
            return View();
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Register(Registertbl r)
        {
            if (ModelState.IsValid)
            {
                dc.Registertbls.Add(r);
                int i = dc.SaveChanges();
                if (i > 0)
                {
                    ViewData["v"] = "User created Sucessfully...!";
                }
            }
            return View();
        }
        public ViewResult Products()
        {
             var res= from t in dc.products
                      select t;
           // int i = 100;

            return View(res.ToList());
        }
        [HttpGet]
        public ActionResult Buy(string pid)
        {
            var res= from t in dc.products
                     where t.pid == pid
                     select t;
            if (Session["uid"]!= null)
            {
                return View(res);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
       
        [HttpPost]
        public ActionResult Buy(FormCollection f)
        {
            userorder u = new userorder();
            u.username = Session["uid"].ToString();
            u.transdate = DateTime.Now;
            u.qty = int.Parse(f["qty"].ToString());

            dc.userorders.Add(u);
            int i = dc.SaveChanges();
            if (i > 0)
            {
                ViewData["r"] = "Your order is plsced successfully...!";
            }
            return View();
        }
        public ActionResult Search(string pname)
        {
            var res = from t in dc.products
                      where t.pname.Contains(pname)
                      select t;
            if (res.Count() > 0)
            {
                return View(res.ToList());
            }
            else
            {
                ViewData["r"] = "No result Found";
            }
            return View();
        }
        public ViewResult Logout()
        {
            Session["uid"] = null;
            return View();

        }
    }
}