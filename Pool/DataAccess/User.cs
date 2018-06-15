namespace Pool.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
