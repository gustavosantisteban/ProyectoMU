using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("DetallePrestamos")]
    public class DetallePrestamo
    {
        public DetallePrestamo()
        {
            this.IdDetallePrestamo = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdDetallePrestamo { get; set; }
        public int CuotaPeriodo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaPago { get; set; }
        
        [Required]
        public string IdPrestamo { get; set; }

        [ForeignKey("IdPrestamo")]
        public virtual Prestamo Prestamo { get; set; }
    }

    //public enum EstadoPrestamo
    //{
    //    Pendiente = 1,
    //    Pagado = 2,
    //    Impago = 3,
    //    Rechazado = 4
    //}
}