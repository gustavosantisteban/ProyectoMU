using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SeguridadWebv2.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models
{
    public class InicializarDatos
    {
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            //Admnistrador
            const string nombre = "William Gustavo";
            const bool estado = true;
            const string name = "administrador@amdr.com.ar";
            const string password = "Mcga@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, Nombre = nombre, Estado = estado, EmailConfirmed = true };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var groupManager = new GrupoManager();
            var newGroup = new ApplicationGroup("Administradores", "Acceso General al Sistema");

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
            //Fin Admnistrador

            var provincias = new List<Provincia> {
                new Provincia {
                    Description = "Buenos Aires"
                },
                new Provincia {
                    Description = "Santa Fé"
                },
                new Provincia {
                    Description = "Entre Rios"
                },
                new Provincia {
                    Description = "Cordoba"
                }
            };
            provincias.ForEach(c => db.Provincias.Add(c));

            var localidades = new List<Localidad>
            {
                new Localidad {
                    Description = "Rosario",
                    CodigoPostal = 2000,
                    Estado = true,
                    Provincia = provincias[0]
                },
                new Localidad {
                    Description = "Roldan",
                    CodigoPostal = 2010,
                    Estado = true,
                    Provincia = provincias[0]
                },
                new Localidad {
                    Description = "Funes",
                    CodigoPostal = 2005,
                    Estado = true,
                    Provincia = provincias[0]
                }
            };
            localidades.ForEach(c => db.Localidades.Add(c));

            var categoriaasoc = new List<CategoriaAsociado>
            {
                new CategoriaAsociado {
                    DescripcionCategoria = "Ministerio de Salud",
                    Estado = true
                },
                new CategoriaAsociado {
                    DescripcionCategoria = "Ministerio de Educación",
                    Estado = true
                },
                new CategoriaAsociado {
                     DescripcionCategoria = "Ministerio de Justicia",
                    Estado = true
                },
                new CategoriaAsociado {
                     DescripcionCategoria = "Ministerio de Trabajo",
                    Estado = true
                },
            };
            categoriaasoc.ForEach(c => db.CategoriaAsociado.Add(c));

            var profesiones = new List<Profesion>
            {
                new Profesion
                {
                    Descripcion = "Ingenieria en Sistemas",
                    Estado = true,
                },
                new Profesion
                {
                    Descripcion = "Arquitecto",
                    Estado = true,
                },
                new Profesion
                {
                    Descripcion = "Diseñador Gráfico",
                    Estado = true,
                },
                new Profesion
                {
                    Descripcion = "Herrero",
                    Estado = true,
                },
            };
            profesiones.ForEach(c => db.Profesiones.Add(c));

            var sexo = new List<Sexo>
            {
                new Sexo
                {
                    Descripcion = "Hombre",
                    Estado = true,
                },
                new Sexo
                {
                    Descripcion = "Mujer",
                    Estado = true,
                },
                new Sexo
                {
                    Descripcion = "No Aplica",
                    Estado = true,
                },
            };
            sexo.ForEach(c => db.Sexo.Add(c));

            var tipodocumento = new List<TipoDocumento>
            {
                new TipoDocumento
                {
                    Descripcion = "DNI",
                    Estado = true,                    
                },
                new TipoDocumento
                {
                    Descripcion = "Pasaporte",
                    Estado = true,
                },
                new TipoDocumento
                {
                    Descripcion = "Libreta Errolamiento",
                    Estado = true,
                },
                new TipoDocumento
                {
                    Descripcion = "Cedula de Identidad",
                    Estado = true,
                },
            };
            tipodocumento.ForEach(c => db.TipoDocumento.Add(c));

            var estadocivil = new List<EstadoCivil>
            {
                new EstadoCivil
                {
                    Descripcion = "Soltero",
                    Estado = true
                },
                new EstadoCivil
                {
                    Descripcion = "Casado",
                    Estado = true
                },
                new EstadoCivil
                {
                    Descripcion = "Viudo",
                    Estado = true
                },
                new EstadoCivil
                {
                    Descripcion = "Divorciado",
                    Estado = true
                },
            };
            estadocivil.ForEach(c => db.EstadoCivil.Add(c));
            
            var entidad = new List<Entidad>
            {
                new Entidad
                {
                    Descripcion = "Entidad de Prestamo 1",
                    Comision = 35M,
                    Estado = true
                },
                new Entidad
                {
                    Descripcion = "Entidad de Prestamo 2",
                    Comision = 15M,
                    Estado = true
                },
                new Entidad
                {
                    Descripcion = "Entidad de Prestamo 3",
                    Comision = 10M,
                    Estado = true
                }
            };
            entidad.ForEach(c => db.Entidad.Add(c));

            var tiporequisito = new List<TipoRequisito>
            {
                new TipoRequisito
                {
                    Descripcion = "Tipo de Requisito 1",
                    Estado = true,
                },
                new TipoRequisito
                {
                    Descripcion = "Tipo de Requisito 2",
                    Estado = true,
                },
            };
            tiporequisito.ForEach(c => db.TipoRequisito.Add(c));

            var requisitos = new List<Requisito>
            {
                new Requisito
                {
                    Descripcion = "Requisito 1",
                    Adjunto = true,
                    CantidadAdjuntos = 2,
                    Estado = true,
                    TipoRequisito = tiporequisito[1]
                },
                new Requisito
                {
                    Descripcion = "Requisito 2",
                    Adjunto = true,
                    CantidadAdjuntos = 1,
                    Estado = true,
                    TipoRequisito = tiporequisito[0]
                },
                new Requisito
                {
                    Descripcion = "Requisito 3",
                    Adjunto = true,
                    CantidadAdjuntos = 1,
                    Estado = true,
                    TipoRequisito = tiporequisito[1]
                },
            };
            requisitos.ForEach(c => db.Requisitos.Add(c));

            var prestamo = new List<TipoPrestamo>
            {
                new TipoPrestamo
                {
                    Descripcion = "Prestamo 1",
                    EntidadPrestamo = entidad[0],
                    Estado = true,
                    Requisitos = null,
                    EscalaCuotas = null,
                },
                new TipoPrestamo
                {
                    Descripcion = "Prestamo 2",
                    EntidadPrestamo = entidad[1],
                    Estado = true,
                    Requisitos = requisitos,
                    EscalaCuotas = null
                },
            };
            prestamo.ForEach(c => db.TipoPrestamos.Add(c));

            var PermisosUsuario = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Usuario"
                },
                new ApplicationRole {
                    Name = "Editar_Usuario"
                },
                new ApplicationRole {
                    Name = "Detalle_Usuario"
                },
                new ApplicationRole {
                    Name = "Eliminar_Usuario"
                },
                new ApplicationRole {
                    Name = "AllUsuarios"
                }
            };
            PermisosUsuario.ForEach(c => db.Roles.Add(c));


            var PermisosGrupo = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Grupo"
                },
                new ApplicationRole {
                    Name = "Editar_Grupo"
                },
                new ApplicationRole {
                    Name = "Detalle_Grupo"
                },
                new ApplicationRole {
                    Name = "Eliminar_Grupo"
                },
                new ApplicationRole {
                    Name = "AllGrupos"
                }
            };
            PermisosGrupo.ForEach(c => db.Roles.Add(c));


            var PermisosAcciones = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Agregar_Permiso"
                },
                new ApplicationRole {
                    Name = "Editar_Permiso"
                },
                new ApplicationRole {
                    Name = "Detalle_Permiso"
                },
                new ApplicationRole {
                    Name = "Eliminar_Permiso"
                },
                new ApplicationRole {
                    Name = "AllPermisos"
                }
            };
            PermisosUsuario.ForEach(c => db.Roles.Add(c));

            var PermisosTurnos = new List<ApplicationRole> {
                new ApplicationRole {
                    Name = "Vendedor"
                },
                new ApplicationRole {
                    Name = "Organizador"
                }
            };
            PermisosTurnos.ForEach(c => db.Roles.Add(c));

            var grupos = new List<ApplicationGroup> {
                new ApplicationGroup {
                    Name = "Gestionar Usuarios",
                    Description = "Gestionar Usuarios"
                },
                new ApplicationGroup {
                    Name = "Gestionar Grupos",
                    Description = "Gestionar Grupos"
                },
                new ApplicationGroup {
                    Name = "Gestionar Acciones",
                    Description = "Gestionar Acciones"
                }
             };
            grupos.ForEach(c => db.ApplicationGroups.Add(c));

            ////Organizador
            //const string nombreorg = "Will Organizador";
            //const string apellidopaternoorg = "Santisteban";
            //const string apellidomaternoorg = "Crack";
            //const bool estadoorg = true;
            //const string nameorg = "rootsantisteban2@gmail.com";
            //const string passwordorg = "Mcga@123456";
            ////const string roleNameorg = "Organizador";

            ////Create Role Organizador if it does not exist
            ////var roleorg = roleManager.FindByName(roleNameorg);
            ////if (roleorg == null)
            ////{
            ////    roleorg = new ApplicationRole(roleNameorg);
            ////    var roleresult2 = roleManager.Create(roleorg);
            ////}

            //var organizador = userManager.FindByName(nameorg);
            //if (organizador == null)
            //{
            //    organizador = new Organizador
            //    {
            //        UserName = nameorg,
            //        Email = nameorg,
            //        Nombre = nombreorg,
            //        ApellidoMaterno = apellidomaternoorg,
            //        ApellidoPaterno = apellidopaternoorg,
            //        Estado = estadoorg,
            //        EmailConfirmed = true,
            //        TipoDocumento = tipodocumento[0],
            //        Sexo = sexo[0],
            //        Localidad = localidades[1],
            //        EstadoCivil = estadocivil[0],
            //        TelefonoCelular = "341354472",
            //        TelefonoFijo = "341354417",
            //        TelefonoLaboral = "000000",
            //        TelefonoResidencia = "000000",
            //        PhoneNumber = "3413544172",
            //        NumeroDocumento = "94566808",
            //        Calle = "Presidente Roca",
            //        Altura = "976",
            //        CBU = "22225321",
            //        CUIT_CUIL = "20945668084",
            //        LugarDeTrabajo = "Twice Talent SRL",
            //        FechaDeNacimiento = DateTime.Parse("03-03-2016"),
            //        Imagen = "~/Content/img/doctor.png",
            //        Observaciones = ""
            //    };

            //    var result1 = userManager.Create(organizador, passwordorg);
            //    result1 = userManager.SetLockoutEnabled(organizador.Id, false);
            //}
            
            //var newGrouporg = new ApplicationGroup("Organizadores", "Acceso Roles Organizador");

            //groupManager.CreateGroup(newGrouporg);
            //groupManager.SetUserGroups(organizador.Id, new string[] { newGrouporg.Id });
            //groupManager.SetGroupRoles(newGrouporg.Id, new string[] { PermisosTurnos[0].Name });
            ////Fin Organizador

            ////Vendedor
            //const string nombrevend = "Gusti Vendedor";
            //const string apellidopaternovend = "Santis";
            //const string apellidomaternovend = "Vendedor";
            //const bool estadovend = true;
            //const string namevend = "williamcitoarg@gmail.com";
            //const string passwordvend = "Mcga@123456";
            ////const string roleNamevend = "Vendedor";

            ////Create Role Admin if it does not exist
            ////var rolevend = roleManager.FindByName(roleNamevend);
            ////if (rolevend == null)
            ////{
            ////    rolevend = new ApplicationRole(roleNamevend);
            ////    var roleresult3 = roleManager.Create(rolevend);
            ////}

            //var vendedor = userManager.FindByName(namevend);
            //if (vendedor == null)
            //{
            //    vendedor = new Vendedor
            //    {
            //        UserName = namevend,
            //        Email = namevend,
            //        Nombre = nombrevend,
            //        ApellidoMaterno = apellidomaternovend,
            //        ApellidoPaterno = apellidopaternovend,
            //        Estado = estadovend,
            //        EmailConfirmed = true,
            //        TipoDocumento = tipodocumento[0],
            //        Sexo = sexo[0],
            //        Localidad = localidades[1],
            //        EstadoCivil = estadocivil[0],
            //        TelefonoCelular = "3413588888",
            //        TelefonoFijo = "3413588888",
            //        PhoneNumber = "3413588888",
            //        NumeroDocumento = "94566809",
            //        Calle = "Presidente Roca",
            //        Altura = "200",
            //        CBU = "222253222",
            //        CUIT_CUIL = "20945668094",
            //        LugarDeTrabajo = "Accenture SRL",
            //        FechaDeNacimiento = DateTime.Parse("03-03-2009"),
            //        Imagen = "~/Content/img/doctor.png",
            //        Observaciones = "",
            //        IdOrganizador = organizador.Id
            //    };

            //    var result2 = userManager.Create(vendedor, passwordvend);
            //    result2 = userManager.SetLockoutEnabled(vendedor.Id, false);
            //}

            //var newGroupvend = new ApplicationGroup("Vendedores", "Acceso Roles Vendedor");

            //groupManager.CreateGroup(newGroupvend);
            //groupManager.SetUserGroups(vendedor.Id, new string[] { newGroupvend.Id });
            //groupManager.SetGroupRoles(newGroupvend.Id, new string[] { PermisosTurnos[1].Name });
            ////Fin Vendedor
            db.SaveChanges();
        }
    }
}