using Pool.DataAccess;
using Pool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public static List<TablesViewModel> GetFreeTables()
        {
            List<TablesViewModel> freeTables = new List<TablesViewModel>();

            using(DatabaseModel model = new DatabaseModel())
            {
                var tables = model.PoolTables.Where(x => x.IsOccupied == false).ToList();

                tables.ForEach(x => freeTables.Add(new TablesViewModel() { TableID = x.PoolTableID, TableName = x.Name }));
            }

            return freeTables;
        }
    }
}