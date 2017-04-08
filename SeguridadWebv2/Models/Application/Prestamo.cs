using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Prestamo")]
    public class Prestamo
    {
        public Prestamo()
        {
            this.IdPrestamo = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdPrestamo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public string IdEntidad { get; set; }

        [ForeignKey("IdEntidad")]
        public virtual Entidad EntidadPrestamo { get; set; }
        public virtual List<Requisito> Requisitos { get; set; }
        public virtual List<EscalaCuota> EscalaCuotas { get; set; }
    }
}