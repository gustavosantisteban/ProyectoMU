using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.ViewModels
{
    public class RegistrarEntidadViewModel
    {
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Required]
        [Display(Name = "Comision")]
        public Decimal Comision { get; set; }
    }

    public class EditarEntidadViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Required]
        [Display(Name = "Comision")]
        public Decimal Comision { get; set; }
    }
}