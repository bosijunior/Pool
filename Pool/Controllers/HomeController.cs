using Pool.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pool.Controllers
{
    public class HomeController : Controller
    {
        //[CustomAuthorize(Roles = "Employee")]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "Visitor")]
        public ActionResult Index2()
        {
            return View();
        }
    }
}