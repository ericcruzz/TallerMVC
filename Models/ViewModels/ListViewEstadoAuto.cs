using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerMVC.Models.ViewModels
{
    public class ListViewEstadoAuto
    {
        public int idEstadoAuto { get; set; }
        public string condicion { get; set; }
        public string inventario { get; set; }
        public System.DateTime FechaEdo { get; set; }
        public string coche { get; set; }
    }
}