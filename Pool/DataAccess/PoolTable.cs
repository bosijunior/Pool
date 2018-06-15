namespace Pool.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PoolTable
    {
        public PoolTable()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PoolTableID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool IsOccupied { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
