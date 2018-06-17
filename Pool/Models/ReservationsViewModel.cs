using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pool.Models
{
    public class ReservationsViewModel
    {
        [Display(Name = "ReservationID")]
        public int ReservationID { get; set; }

        [Display(Name = "Table name")]
        public string TableName { get; set; }

        [Display(Name = "Visitor")]
        public string Visitor { get; set; }

        [Display(Name = "Time")]
        public DateTime Time { get; set; }
    }
}