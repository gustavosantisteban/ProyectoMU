using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SeguridadWebv2.Models;
using SeguridadWebv2.Models.Application;
using SeguridadWebv2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeguridadWebv2.Controllers
{
    public class OrganizadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public OrganizadorController()
        {
        }

        public OrganizadorController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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
        [Authorize(Roles = "Admin")]
        public ActionResult Agregar()
        {
            RegistrarOrgViewModel registrarse = new RegistrarOrgViewModel();
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
        public async Task<ActionResult> Agregar(RegistrarOrgViewModel model)
        {
            model.Estado = true;
            if (ModelState.IsValid)
            {
                string pathimage = "~/Content/img/doctor.png";
                Organizador user = new Organizador {
                        UserName = model.Email,
                        Email = model.Email, 
                        Nombre = model.Nombre,
                        ApellidoMaterno = model.ApellidoMaterno,
                        ApellidoPaterno = model.ApellidoPaterno,
                        Estado = model.Estado,
                        PhoneNumber = model.TelefonoCelular,
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
                var result = await UserManager.CreateAsync(user, model.Password);
                GrupoManager groupManager = new GrupoManager();
                var group = db.ApplicationGroups.Where(x => x.Name == "Organizador").FirstOrDefault();
                groupManager.SetUserGroups(user.Id, group.Id);
                if (result.Succeeded)
                {
                    //await this.groupManager.SetUserGroups(user.Id, "Profesionales");
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmarEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirmar su cuenta", "Por favor para confirmar su cuenta haga click en el siguiente enlace: <a href=\"" + callbackUrl + "\">link</a>");

                    //ViewBag.Link = callbackUrl;
                    return View("~/Views/Account/DisplayEmail.cshtml");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Editar(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Display a list of available Groups:

            var model = new EditarOrgViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Nombre = user.Nombre,
                ApellidoMaterno = user.ApellidoMaterno,
                Estado = user.Estado
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(EditarOrgViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Update the User:
                user.UserName = editUser.Email;
                user.Email = editUser.Email;
                user.Nombre = editUser.Nombre;
                user.ApellidoMaterno = editUser.ApellidoMaterno;
                user.ApellidoPaterno = editUser.ApellidoPaterno;
                user.Estado = editUser.Estado;
                await this.UserManager.UpdateAsync(user);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }


        [Authorize(Roles = "Admin, Eliminar_Usuario")]
        public async Task<ActionResult> Eliminar(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmarEliminar(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Then Delete the User:
                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}