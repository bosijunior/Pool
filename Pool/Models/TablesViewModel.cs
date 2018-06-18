using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Pool.Models
{
    public class TablesViewModel
    {
        public int SelectedTableID { get; set; }

        [Display(Name = "Reservation time")]
        public DateTime SelectedDate { get; set; }


        [Display(Name = "Free tables")]
        public ICollection<SelectListItem> Tables { get; set; }


        public TablesViewModel() { }

        public TablesViewModel(int selectedTableID, DateTime selectedDate, List<SelectListItem> tables)
        {
            SelectedTableID = selectedTableID;
            SelectedDate = selectedDate;
            Tables = tables;
        }
    }
}