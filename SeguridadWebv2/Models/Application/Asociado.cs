using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Asociados")]
    public class Asociado
    {
        public Asociado()
        {
            this.IdAsociado = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdAsociado { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(60)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(60)]
        public string ApellidoPaterno { get; set; }
        public bool Estado { get; set; }

        [Required]
        [StringLength(8)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(11)]
        public string CUIT_CUIL { get; set; }
        [Required]
        [StringLength(100)]
        public string Calle { get; set; }
        [Required]
        [StringLength(30)]
        public string Altura { get; set; }
        public string Block { get; set; }
        public string Departamento { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        [StringLength(11)]
        public string TelefonoCelular { get; set; }
        [Required]
        [StringLength(10)]
        public string TelefonoFijo { get; set; }
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
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public string Imagen { get; set; }
        //Foreing
        public string IdTipoDocumento { get; set; }
        public string IdEstadoCivil { get; set; }
        public string IdLocalidad { get; set; }
        public string IdSexo { get; set; }
        public string IdProfesion { get; set; }
        public string IdCategoria { get; set; }
        //Fin Foreing

        [ForeignKey("IdTipoDocumento")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        [ForeignKey("IdEstadoCivil")]
        public virtual EstadoCivil EstadoCivil { get; set; }
        [ForeignKey("IdLocalidad")]
        public virtual Localidad Localidad { get; set; }
        [ForeignKey("IdSexo")]
        public virtual Sexo Sexo { get; set; }
        [ForeignKey("IdProfesion")]
        public virtual Profesion Profesion { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual CategoriaAsociado Categoria { get; set; }
    }
}