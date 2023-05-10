using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTU_SINH.Controllers
{
    public class KhoaTuController : Controller
    {
        // GET: KhoaTu
        public ActionResult DanhSachKhoaTu()
        {
            return View();
        }
    }
}