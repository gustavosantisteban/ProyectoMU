using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("CategoriaAsociado")]
    public class CategoriaAsociado
    {
        public CategoriaAsociado()
        {
            this.IdCategoriaAsociado = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdCategoriaAsociado { get; set; }
        public string DescripcionCategoria { get; set; }
        public bool Estado { get; set; }

    }
}