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
        [Display(Name = "Table ID")]
        public int TableID { get; set; }

        [Display(Name = "Table name")]
        public string TableName { get; set; }
    }

    public class TablesPackage
    {
        public string SelectedItem { get; set; }

        public ICollection<SelectListItem> Tables { get; set; }

        public TablesPackage(string selectedItem, List<SelectListItem> tables)
        {
            SelectedItem = selectedItem;
            Tables = tables;
        }
    }
}