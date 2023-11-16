using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TallerMVC.Models.ViewModels
{
    public class NuevoCliente
    {
        public int idCliente { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string sexo { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Required]
        [Display(Name = "Número Telefónico")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string correo { get; set; }
    }
}