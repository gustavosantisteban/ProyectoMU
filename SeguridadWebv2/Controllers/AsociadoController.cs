using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
    public class AsociadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public AsociadoController()
        {
        }

        public AsociadoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }


        // GET: Organizador
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Vendedor")]
        public ActionResult Registrarse()
        {
            RegistrarVendViewModel registrarse = new RegistrarVendViewModel();
            ViewBag.TipoDocumento = db.TipoDocumento.ToList();
            ViewBag.Organizadores = db.Organizadores.Where(x => x.Estado == true).ToList();
            ViewBag.Localidades = db.Localidades.Where(x => x.Estado == true).ToList();
            ViewBag.Sexo = db.Sexo.Where(x => x.Estado == true).ToList();
            ViewBag.EstadoCivil = db.EstadoCivil.Where(x => x.Estado == true).ToList();
            return View(registrarse);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrarse(RegistrarAsocViewModel model)
        {
            model.Estado = true;
            if (ModelState.IsValid)
            {
                string pathimage = "~/Content/img/doctor.png";
                Asociado user = new Asociado
                {
                    Nombre = model.Nombre,
                    ApellidoMaterno = model.ApellidoMaterno,
                    ApellidoPaterno = model.ApellidoPaterno,
                    Estado = model.Estado,
                    TelefonoCelular = model.TelefonoCelular,
                    TelefonoFijo = model.TelefonoFijo,
                    TelefonoLaboral = model.TelefonoLaboral,
                    TelefonoResidencia = model.TelefonoResidencia,
                    Altura = model.Altura,
                    Block = model.Block,
                    Calle = model.Calle,
                    CBU = model.CBU,
                    CBU_2 = model.CBU_2,
                    CBU_3 = model.CBU_3,
                    CUIT_CUIL = model.CUIT_CUIL,
                    Departamento = model.Departamento,
                    IdEstadoCivil = model.IdEstadoCivil,
                    IdLocalidad = model.IdLocalidad,
                    IdSexo = model.IdSexo,
                    IdTipoDocumento = model.IdTipoDocumento,
                    FechaDeNacimiento = model.FechaDeNacimiento,
                    LugarDeTrabajo = model.LugarDeTrabajo,
                    NumeroDocumento = model.NumeroDocumento,
                    Observaciones = model.Observaciones,
                    Imagen = pathimage
                };
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

       
    }
}