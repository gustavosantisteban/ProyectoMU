using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Sexo")]
    public class Sexo
    {
        public Sexo()
        {
            this.IdSexo = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdSexo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}