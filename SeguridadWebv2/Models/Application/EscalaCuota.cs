using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("EscalaCuota")]
    public class EscalaCuota
    {
        public EscalaCuota()
        {
            this.IdEscalaCuota = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdEscalaCuota { get; set; }
        public Decimal Importe { get; set; }
        public int CantidadCuotas { get; set; }
        public bool Estado { get; set; }
        public string IdPrestamo { get; set; }

        [ForeignKey("IdPrestamo")]
        public virtual Prestamo Prestamo { get; set; }
    }
}