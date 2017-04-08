using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("TipoRequisito")]
    public class TipoRequisito
    {
        public TipoRequisito()
        {
            this.IdTipoRequisito = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdTipoRequisito { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}