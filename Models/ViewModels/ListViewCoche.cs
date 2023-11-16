using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerMVC.Models.ViewModels
{
    public class ListViewCoche
    {
        public int idCoche { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int anio { get; set; }
        public string color { get; set; }
        public string cliente { get; set; }
    }
}