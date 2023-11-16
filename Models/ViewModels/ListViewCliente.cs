using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerMVC.Models.ViewModels
{
    public class ListViewCliente
    {
        public int idCliente { get; set; }
        public string nombreCompleto { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }
}