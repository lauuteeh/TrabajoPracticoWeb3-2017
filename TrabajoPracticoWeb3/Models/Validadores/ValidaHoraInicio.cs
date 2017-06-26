using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TrabajoPracticoWeb3.Models
{

    public class ValidaHoraInicio : ValidationAttribute
    {
        private readonly string _horaInicio;

        public ValidaHoraInicio(string horaInicio)
        {
            _horaInicio = horaInicio;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propertyHoraInicio = validationContext.ObjectType.GetProperty(_horaInicio);

            var fieldValueHoraInicio = propertyHoraInicio.GetValue(validationContext.ObjectInstance, null);

            var stringHoraInicio = Convert.ToString(fieldValueHoraInicio);
            if (stringHoraInicio.Length == 4)
            {
                var minutos = stringHoraInicio.Substring(2, 2);
                var hora = stringHoraInicio.Substring(0,2);

                if (!ValidRange(minutos, hora))
                    return new ValidationResult("Hora Inicio debe ser mayor o igual a 1500(15:00hs) y menor a 1800(18:00hs)");
            }
            return null;
        }

        private bool ValidRange(string min, string hor)
        {
            const int minHora = 15;
            const int maxHora = 17;
            const int minMinutos = 0;
            const int maxMinutos = 59;

            int minutos = Convert.ToInt32(min);
            int hora = Convert.ToInt32(hor);

            return (minutos >= minMinutos && minutos <= maxMinutos) &&
                (hora >= minHora && hora <= maxHora);
        }

    }

}

