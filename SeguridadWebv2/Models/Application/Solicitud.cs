using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Solicitud")]
    public class Solicitud
    {
        public Solicitud()
        {
            this.IdSolicitud = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Importe { get; set; }

        //Foreing
        public string IdVendedor { get; set; }
        public string IdAsociado { get; set; }
        public string IdPrestamo { get; set; }

        //Fin Foreing

        [ForeignKey("IdVendedor")]
        public virtual Vendedor Vendedor { get; set; }
        [ForeignKey("IdAsociado")]
        public virtual Asociado Asociado { get; set; }
        [ForeignKey("IdPrestamo")]
        public virtual Prestamo Prestamo { get; set; }
    }
}