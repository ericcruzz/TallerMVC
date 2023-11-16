using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TallerMVC.Models.ViewModels
{
    public class NuevoEstadoAuto
    {
        public int idEstadoAuto { get; set; }
        [Required]
        [Display(Name = "Condicion")]
        public string condicion { get; set; }
        [Required]
        [Display(Name = "Cosas encontradas en la unidad")]
        public string inventario { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public System.DateTime FechaEdo { get; set; }
        [Required]
        [Display(Name = "Coche")]
        public int cocheId { get; set; }
    }

}