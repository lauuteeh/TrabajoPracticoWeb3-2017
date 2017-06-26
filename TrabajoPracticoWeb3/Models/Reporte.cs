using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoPracticoWeb3.App_Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TrabajoPracticoWeb3.Models
{
    public class Reporte
    {

        
        [Required(ErrorMessage = "Se requiere Fecha")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Se requiere Fecha")]
        public DateTime FechaFin { get; set; }

    }
}