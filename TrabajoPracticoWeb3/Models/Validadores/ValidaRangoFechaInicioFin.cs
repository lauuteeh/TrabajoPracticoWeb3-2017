using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TrabajoPracticoWeb3.Models
{

    public class ValidaRangoFechaInicioFin : ValidationAttribute
    {
        private readonly string _fechaInicio;
        private readonly string _fechaFin;

        public ValidaRangoFechaInicioFin(string fechaInicio, string fechaFin)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propertyFechaInicio = validationContext.ObjectType.GetProperty(_fechaInicio);
            PropertyInfo propertyFechaFin = validationContext.ObjectType.GetProperty(_fechaFin);

            var fieldValueFechaInicio = propertyFechaInicio.GetValue(validationContext.ObjectInstance, null);
            var fieldValueFechaFin = propertyFechaFin.GetValue(validationContext.ObjectInstance, null);

            if ((DateTime)fieldValueFechaInicio <= (DateTime)fieldValueFechaFin) { 
                if (((DateTime)fieldValueFechaFin - (DateTime)fieldValueFechaInicio).TotalDays <= 30)
                    return null;
                else
                    return new ValidationResult("El rango de fechas no debe ser mayor a 30 dias");
            }
            else { 
                return new ValidationResult("Fecha Inicio debe ser menor o igual a fecha fin");
            }
        }

    }

}

