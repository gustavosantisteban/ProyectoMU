using System;
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
        public string LugarDeTrabajo { get; set; }
        public string CBU { get; set; }
        public string CBU_2 { get; set; }
        public string CBU_3 { get; set; }
        public string Observaciones { get; set; }

        //Foreign
        public string IdEstadoCivil { get; set; }
        public string IdLocalidad { get; set; }
        public string IdSexo { get; set; }
        public string IdOrganizador { get; set; }
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