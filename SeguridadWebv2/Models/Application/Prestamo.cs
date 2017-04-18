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
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaAcreditacion { get; set; }
        public bool Estado { get; set; }
        public Decimal Importe { get; set; }
        public int CantidadCuotas { get; set; }

        [Required]
        public string IdAsociado { get; set; }
        [Required]
        public string IdVendedor { get; set; }

        [ForeignKey("IdAsociado")]
        public virtual Asociado Asociado { get; set; }
        [ForeignKey("IdVendedor")]
        public virtual Vendedor Vendedor { get; set; }

        public virtual List<DetallePrestamo> DetallePrestamo { get; set; }
        public virtual List<EscalaCuota> EscalaCuotas { get; set; }
    }
}