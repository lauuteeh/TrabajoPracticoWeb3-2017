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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using TrabajoPracticoWeb3.Models;

    public partial class Carteleras
    {

        public int IdCartelera { get; set; }

        [DisplayName("Sede")]
        public int IdSede { get; set; }

        [DisplayName("Película")]
        public int IdPelicula { get; set; }

        [DisplayName("Hora Inicio")]
        [Required(ErrorMessage = "Se requiere Hora inicio")]
        [RegularExpression(@"^[0-9]{4,4}$", ErrorMessage = "Hora de inicio debe ser numérico y contener 4 caracteres")]
        public int HoraInicio { get; set; }

        [DisplayName("Fecha Inicio")]
        [Required(ErrorMessage = "Se requiere Fecha inicio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public System.DateTime FechaInicio { get; set; }

        [DisplayName("Fecha Fin")]
        [Required(ErrorMessage = "Se requiere Fecha fin")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [ValidaRangoFechaInicioFin("FechaInicio", "FechaFin")]
        public System.DateTime FechaFin { get; set; }

        [DisplayName("Número de Sala")]
        [Required(ErrorMessage = "Se requiere una sala")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Número de Sala debe ser numérico")]
        [RegularExpression(@"^[0-9]{1,4}$", ErrorMessage = "Número de Sala debe ser numérico y contener hasta 4 caracteres")]
        public int NumeroSala { get; set; }

        [DisplayName("Versión")]
        public int IdVersion { get; set; }

        [MinimoUnCampoRequerido(new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" })]
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }

        public System.DateTime FechaCarga { get; set; }
        public virtual Peliculas Peliculas { get; set; }
        public virtual Sedes Sedes { get; set; }
        public virtual Versiones Versiones { get; set; }
    }
}
