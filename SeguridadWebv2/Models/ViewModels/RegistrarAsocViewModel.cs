using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.ViewModels
{
    public class RegistrarAsocViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        public bool Estado { get; set; }
        [Required]
        public string NumeroDocumento { get; set; }
        [Required]
        public string CUIT_CUIL { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string Altura { get; set; }
        public string Block { get; set; }
        public string Departamento { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public string TelefonoFijo { get; set; }
        [Required]
        public string TelefonoLaboral { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoResidencia { get; set; }
        [Required]
        public string LugarDeTrabajo { get; set; }
        [Required]
        public string CBU { get; set; }
        public string CBU_2 { get; set; }
        public string CBU_3 { get; set; }

        public string Observaciones { get; set; }
        public string Imagen { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //Foreing
        [Required]
        public string IdEstadoCivil { get; set; }
        [Required]
        public string IdLocalidad { get; set; }
        [Required]
        public string IdSexo { get; set; }
        [Required]
        public string IdTipoDocumento { get; set; }
    }
}