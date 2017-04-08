using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("EstadoCivil")]
    public class EstadoCivil
    {
        public EstadoCivil()
        {
            this.IdEstadoCivil = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdEstadoCivil { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}