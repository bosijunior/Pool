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
            var reservations = ReservationsManager.GetReservations().OrderBy(o => o.Time);
            return View(reservations);
        }

        [CustomAuthorize(Roles = "Visitor")]
        public ActionResult ReserveTable()
        {
            return View(GetReserveTablesViewData());
        }

        [HttpPost]
        public ActionResult ReserveTable(TablesViewModel tablesView)
        {
            if (tablesView.SelectedDate == null)
            {
                ModelState.AddModelError("", "Date cannot be null");
                return View(GetReserveTablesViewData());
            }

            ReservationsManager.CreateReservation(tablesView);

            return View(GetReserveTablesViewData());
        }

        private TablesViewModel GetReserveTablesViewData()
        {
            List<SelectListItem> selectOptions = new List<SelectListItem>();

            var freeTables = ReservationsManager.GetFreeTables();
            freeTables.ForEach(x => selectOptions.Add(new SelectListItem { Text = x.Name, Value = x.PoolTableID.ToString() }));

            return new TablesViewModel(0, DateTime.Now, selectOptions);
        }
    }
}