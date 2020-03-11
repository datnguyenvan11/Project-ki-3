using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ki_3.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }

       
    }
}