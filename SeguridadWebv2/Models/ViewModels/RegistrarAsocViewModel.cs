using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.ViewModels
{
    public class RegistrarAsocViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar el nombre del asociado")]
        [StringLength(100, ErrorMessage = "El nombre del asociado no puede contener mas de 100 caracteres")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar el apellido materno del asociado")]
        [StringLength(100, ErrorMessage = "El apellido materno del asociado no puede contener mas de 100 caracteres")]
        [Display(Name = "Apellido materno:")]
        public string ApellidoMaterno { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar el apellido paterno del asociado")]
        [StringLength(100, ErrorMessage = "El apellido paterno del asociado no puede contener mas de 100 caracteres")]
        [Display(Name = "Apellido paterno:")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [Display(Name ="Estado")]
        public bool Estado { get; set; }
        [RegularExpression("([0-9]+)")]
        [Required(ErrorMessage = "Debe ingresar el número de documento del asociado")]
        [Range(typeof(Int32), "1", "99999999", ErrorMessage = "El número de documento del asociado es incorrecto")]
        [Display(Name = "Nro de documento:")]
        public string NumeroDocumento { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar el CUIT/CULL electrónico del asociado")]
        [Display(Name = "CUIT / CUIL:")]
        public string CUIT_CUIL { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar la calle del domicilio del asociado")]
        [StringLength(200, ErrorMessage = "La calle del domicilio del asociado no puede contener mas de 200 caracteres")]
        [Display(Name = "Calle:")]
        public string Calle { get; set; }
        [RegularExpression("([0-9]+)")]
        [Range(typeof(Int32), "0", "100000", ErrorMessage = "La altura del domicilio ingresado es inválida")]
        [Required(ErrorMessage = "Debe ingresar la altura del domicilio del asociado")]
        public string Altura { get; set; }
        public string Block { get; set; }
        public string Departamento { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Debe ingresar la fecha de nacimiento del asociado")]
        [Display(Name = "Fecha de Nacimiento:")]
        public DateTime FechaDeNacimiento { get; set; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar el número de teléfono fijo del asociado")]
        [StringLength(100, ErrorMessage = "El número de teléfono del asociado no puede contener mas de 100 caracteres")]
        [Display(Name = "Telefono fijo:")]
        public string TelefonoFijo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar el número de teléfono celular del asociado")]
        [StringLength(100, ErrorMessage = "El número de teléfono celular no puede contener mas de 100 caracteres")]
        [Display(Name = "Telefono Celular:")]
        public string TelefonoCelular { get; set; }
        
        public string TelefonoLaboral { get; set; }
        
        public string TelefonoResidencia { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar la descripción del lugar de trabajo del asociado")]
        [StringLength(200, ErrorMessage = "La descripción del lugar de trabajo del asociado no puede contener mas de 200 caracteres")]
        [Display(Name = "Lugar trabajo:")]
        public string LugarDeTrabajo { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar el CBU del asociado")]
        [StringLength(22, ErrorMessage = "El CBU del asociado no puede contener mas de 22 caracteres")]
        [Display(Name = "CBU:")]
        public string CBU { get; set; }
        [DataType(DataType.Text)]
        [StringLength(22, ErrorMessage = "El CBU del asociado no puede contener mas de 22 caracteres")]
        [Display(Name = "CBU2:")]
        public string CBU_2 { get; set; }
        [DataType(DataType.Text)]
        [StringLength(22, ErrorMessage = "El CBU del asociado no puede contener mas de 22 caracteres")]
        [Display(Name = "CBU3:")]
        public string CBU_3 { get; set; }
        public string Piso { get; set; }
        public string Observaciones { get; set; }
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Debe ingresar el correo electrónico del asociado")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //Foreing
        [Required]
        [Display(Name = "Estado Civil")]
        public string IdEstadoCivil { get; set; }
        [Required]
        [Display(Name = "Profesion")]
        public string IdProfesion { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        public string IdCategoriaAsociado { get; set; }
        [Required]
        [Display(Name = "Localidad")]
        public string IdLocalidad { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string IdSexo { get; set; }
        [Required]
        [Display(Name = "Tipo de Documento")]
        public string IdTipoDocumento { get; set; }
    }

    public class EditarAsocViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }

        public string NumeroDocumento { get; set; }
        [Required]
        public string CUIT_CUIL { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string Altura { get; set; }
        public string Block { get; set; }
        public string Departamento { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public string TelefonoFijo { get; set; }
        [Required]
        public string TelefonoLaboral { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoResidencia { get; set; }
        [Required]
        public string LugarDeTrabajo { get; set; }
        [Required]
        public string CBU { get; set; }
        public string CBU_2 { get; set; }
        public string CBU_3 { get; set; }

        public string Observaciones { get; set; }
        public string Imagen { get; set; }

        //Foreing
        [Required]
        public string IdEstadoCivil { get; set; }
        [Required]
        public string IdLocalidad { get; set; }
        [Required]
        public string IdSexo { get; set; }
        [Required]
        public string IdTipoDocumento { get; set; }
        //Fin Foreing
    }
}