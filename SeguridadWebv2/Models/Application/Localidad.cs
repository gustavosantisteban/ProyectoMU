using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{

    [Table("Localidades")]
    public class Localidad
    {
        public Localidad()
        {
            this.IdLocalidad = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdLocalidad { get; set; }
        public string Description { get; set; }
        public int CodigoPostal { get; set; }
        public bool Estado { get; set; }

        public string IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        public virtual Provincia Provincia { get; set; }
    }
}