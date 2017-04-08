using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Entidad")]
    public class Entidad
    {
        public Entidad()
        {
            this.IdEntidad = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdEntidad { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public Decimal Comision { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}