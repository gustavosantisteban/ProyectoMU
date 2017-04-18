using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("TipoPrestamo")]
    public class TipoPrestamo
    {
        public TipoPrestamo()
        {
            this.IdTipoPrestamo = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdTipoPrestamo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [Required]
        public string IdEntidad { get; set; }

        [ForeignKey("IdEntidad")]
        public virtual Entidad EntidadPrestamo { get; set; }
        public virtual List<Requisito> Requisitos { get; set; }
        public virtual List<EscalaCuota> EscalaCuotas { get; set; }
    }
}