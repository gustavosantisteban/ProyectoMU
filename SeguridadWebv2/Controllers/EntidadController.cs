using SeguridadWebv2.Models;
using SeguridadWebv2.Models.Application;
using SeguridadWebv2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeguridadWebv2.Controllers
{
    public class EntidadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Entidad
        public ActionResult Index()
        {
            var resultado = db.Entidad.Where(x => x.Estado == true).ToList();
            return View(resultado);
        }

        [Authorize(Roles = "Admin, Vendedor")]
        public ActionResult Agregar()
        {
            RegistrarEntidadViewModel model = new RegistrarEntidadViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Agregar(RegistrarEntidadViewModel model)
        {
            if (ModelState.IsValid)
            {
                Entidad entidad = new Entidad
                {
                    Comision = model.Comision,
                    Descripcion = model.Descripcion,
                    Estado = model.Estado
                };
                db.Entidad.Add(entidad);
                db.SaveChanges();
            }
            return View(model);
        }
    }
}