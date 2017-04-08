using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Application
{
    [Table("Requisito")]
    public class Requisito
    {
        public Requisito()
        {
            this.IdRequisito = Guid.NewGuid().ToString();
        }

        [Key]
        public string IdRequisito { get; set; }
        public string Descripcion { get; set; }
        public bool Adjunto { get; set; }
        public int CantidadAdjuntos { get; set; }
        public bool Estado { get; set; }
        public string IdTipoRequisito { get; set; }

        [ForeignKey("IdTipoRequisito")]
        public virtual TipoRequisito TipoRequisito { get; set; }
    }
}