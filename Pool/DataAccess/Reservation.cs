namespace Pool.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        public int ReservationID { get; set; }

        public int PoolTableID { get; set; }

        public int UserID { get; set; }

        public DateTime ReservationTime { get; set; }

        public virtual PoolTable PoolTable { get; set; }

        public virtual User User { get; set; }
    }
}
