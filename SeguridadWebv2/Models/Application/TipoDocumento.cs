using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("TipoDocumento")]
    public class TipoDocumento
    {
        public TipoDocumento()
        {
            this.IdTipoDocumento = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}