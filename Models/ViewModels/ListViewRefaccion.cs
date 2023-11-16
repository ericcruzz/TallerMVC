using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerMVC.Models.ViewModels
{
    public class ListViewRefaccion
    {
        public int idRefaccion { get; set; }
        public string tipo { get; set; }
        public double precio { get; set; }
        public Nullable<int> servicioId { get; set; }
    }
}