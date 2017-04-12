﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Vendedor")]
    public class Vendedor : ApplicationUser
    {
        [Required]
        [StringLength(50)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(15)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(15)]
        public string CUIT_CUIL { get; set; }
        [Required]
        [StringLength(100)]
        public string Calle { get; set; }
        [Required]
        [StringLength(50)]
        public string Altura { get; set; }
        public string Block { get; set; }
        public string Departamento { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        [StringLength(15)]
        public string TelefonoFijo { get; set; }
        [Required]
        [StringLength(15)]
        public string TelefonoCelular { get; set; }

        public string TelefonoLaboral { get; set; }
        public string TelefonoResidencia { get; set; }
        [Required]
        [StringLength(100)]
        public string LugarDeTrabajo { get; set; }
        [Required]
        [StringLength(50)]
        public string CBU { get; set; }
        public string CBU_2 { get; set; }
        public string CBU_3 { get; set; }

        public string Observaciones { get; set; }
        public string Imagen { get; set; }

        //Foreign
        [Required]
        public string IdEstadoCivil { get; set; }
        [Required]
        public string IdLocalidad { get; set; }
        [Required]
        public string IdSexo { get; set; }
        [Required]
        public string IdOrganizador { get; set; }
        [Required]
        public string IdTipoDocumento { get; set; }
        //Fin Foreign

        [ForeignKey("IdTipoDocumento")]
        public virtual TipoDocumento TipoDocumento { get; set; }
        [ForeignKey("IdEstadoCivil")]
        public virtual EstadoCivil EstadoCivil { get; set; }
        [ForeignKey("IdLocalidad")]
        public virtual Localidad Localidad { get; set; }
        [ForeignKey("IdSexo")]
        public virtual Sexo Sexo { get; set; }
        [ForeignKey("IdOrganizador")]
        public virtual Organizador Organizador { get; set; }

    }
}