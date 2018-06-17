using Pool.CustomAuthentication;
using Pool.Models;
using Pool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Reservations()
        {
            var reservations = ReservationsManager.GetReservations();
            return View(reservations);
        }

        [CustomAuthorize(Roles = "Visitor")]
        public ActionResult ReserveTable()
        {
            var freeTables = ReservationsManager.GetFreeTables();
            var selectOptions = freeTables.Select(f => new SelectListItem { Text = f.TableName, Value = f.TableID.ToString() }).ToList();
            var tablesPackage = new TablesPackage("", selectOptions);

            return View(tablesPackage);
        }
    }
}