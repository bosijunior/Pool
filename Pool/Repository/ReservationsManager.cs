using Pool.CustomAuthentication;
using Pool.DataAccess;
using Pool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Pool.Repository
{
    public static class ReservationsManager
    {
        public static List<ReservationsViewModel> GetReservations()
        {
            List<ReservationsViewModel> reservationsList = new List<ReservationsViewModel>();

            using (DatabaseModel model = new DatabaseModel())
            {
                var reservations = model.Reservations;
                var tables = model.PoolTables;
                var users = model.Users;

                foreach (var r in reservations)
                {
                    var tableName = tables.FirstOrDefault(t => t.PoolTableID == r.PoolTableID)?.Name;
                    var userName = users.FirstOrDefault(u => u.UserID == r.UserID)?.Username;

                    reservationsList.Add(new ReservationsViewModel() { ReservationID = r.ReservationID, TableName = tableName, Visitor = userName, Time = r.ReservationTime });
                }
            }

            return reservationsList;
        }

        public static List<PoolTable> GetFreeTables()
        {

            using (DatabaseModel model = new DatabaseModel())
            {
                return model.PoolTables.Where(x => x.IsOccupied == false).ToList();
            }
        }

        public static void CreateReservation(TablesViewModel tablesViewModel)
        {
            using (DatabaseModel model = new DatabaseModel())
            {
                var currentUsername = HttpContext.Current.User.Identity.Name;
                var user = (CustomMembershipUser)Membership.GetUser(currentUsername, false);

                // add new reservation
                model.Reservations.Add(new Reservation { UserID = user.UserId, PoolTableID = tablesViewModel.SelectedTableID, ReservationTime = tablesViewModel.SelectedDate });

                // update table occupation
                var selectedtable = model.PoolTables.FirstOrDefault(x => x.PoolTableID == tablesViewModel.SelectedTableID);
                if(selectedtable != null)
                {
                    selectedtable.IsOccupied = true;
                }

                model.SaveChanges();
            }
        }
    }
}