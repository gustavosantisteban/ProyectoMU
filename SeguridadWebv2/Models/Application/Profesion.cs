using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Profesion")]
    public class Profesion
    {
        public Profesion()
        {
            this.IdProfesion = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdProfesion { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}