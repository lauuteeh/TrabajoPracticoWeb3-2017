using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class CarteleraReserva
    {        
        public int IdSede { get; set; }    
        public int IdPelicula { get; set; }            
        public int NumeroSala { get; set; }
        [DisplayName("Versión")]
        public int IdVersion { get; set; }            

        public virtual Peliculas Peliculas { get; set; }
        public virtual Sedes Sedes { get; set; }
        public virtual Versiones Versiones { get; set; }

        public int IdReserva { get; set; }      
        public System.DateTime FechaHoraInicio { get; set; }

        [Required(ErrorMessage = "Se requiere Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Tipo de Documento")]
        [Required(ErrorMessage = "Se requiere tipo de documento")]
        public int IdTipoDocumento { get; set; }

        [DisplayName("Numero de Documento")]
        [RegularExpression(@"^[0-9]{1,8}$", ErrorMessage = "Número de documento debe ser numérico y contener hasta 8 caracteres")]
        [Required(ErrorMessage = "Se requiere número de documento")]
        public string NumeroDocumento { get; set; }

        [DisplayName("Cantidad de Entradas")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Cantidad debe ser mayor que 0")]
        [Required(ErrorMessage = "Se requiere cantidad de entradas")]
        public int CantidadEntradas { get; set; }   
                      
        public virtual TiposDocumentos TiposDocumentos { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }

    }
}