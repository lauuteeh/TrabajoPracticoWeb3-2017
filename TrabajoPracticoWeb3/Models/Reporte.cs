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


        [DisplayName("Fecha Inicio")]
        [Required(ErrorMessage = "Se requiere Fecha inicio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FechaInicio { get; set; }



        [DisplayName("Fecha Fin")]
        [Required(ErrorMessage = "Se requiere Fecha fin")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [ValidaRangoFechaInicioFin("FechaInicio", "FechaFin")]
        public DateTime FechaFin { get; set; }

    }
}