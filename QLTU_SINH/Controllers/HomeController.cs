using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLTU_SINH.Models;
using System.Web.Mvc;

namespace QLTU_SINH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Login()
        {

            ViewBag.Title = "LOGIN ";
            return View();
        }
        public class ThamSo
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        private QLTuSinhEntities db = new QLTuSinhEntities();
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
        
            var user = db.TAI_KHOAN.SingleOrDefault(x => x.USERNAME == username && x.PASSWORD == password);
            if (user != null)
            {
                Session["ISADMIN"] = user.IS_ADMIN;
                Session["USERNAME"] = user.USERNAME;
              
                return RedirectToAction("Index");
            }
            ViewBag.error = "Bạn đã đăng nhập sai";
            return View();
        }
        public ActionResult Logout()
        {

            Session["USERNAME"] = null;
            Session["PASSWORD"] = null;

            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
