//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrabajoPracticoWeb3.App_Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese Usuario!")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese Contraseña!")]
        public string Password { get; set; }
    }
}
