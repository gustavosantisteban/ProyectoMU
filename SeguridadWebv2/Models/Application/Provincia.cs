using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Provincias")]
    public class Provincia
    {
        public Provincia()
        {
            this.IdProvincia = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdProvincia { get; set; }
        public string Description { get; set; }
        public ICollection<Localidad> Localidades { get; set; }
    }
}