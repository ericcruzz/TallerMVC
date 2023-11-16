using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TallerMVC.Models.ViewModels
{
    public class NuevoCoche
    {
        public int idCoche { get; set; }
        [Required]
        [Display(Name = "Placa")]
        public string placa { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }
        [Required]
        [Display(Name = "Modelo")]
        public string modelo { get; set; }
        [Required]
        [Display(Name = "Año")]
        public int anio { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string color { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public int clienteid { get; set; }
    }
}