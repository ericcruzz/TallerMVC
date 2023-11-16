using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TallerMVC.Models.ViewModels
{
    public class NuevaRefaccion
    {
        public int idRefaccion { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public double precio { get; set; }
        [Required]
        [Display(Name = "No. Servicio")]
        public Nullable<int> servicioId { get; set; }
    }
}