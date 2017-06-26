using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TrabajoPracticoWeb3.Models
{

    public class MinimoUnCampoRequerido : ValidationAttribute
    {
        private readonly string[] _fields;

        public MinimoUnCampoRequerido(string[] fields)
        {
            _fields = fields;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = false;

            foreach (string field in _fields)
            {
                PropertyInfo property = validationContext.ObjectType.GetProperty(field);  
                var fieldValue = property.GetValue(validationContext.ObjectInstance, null);
                if ((bool)fieldValue == true)
                    isValid = true;
            }

            if (isValid)
                return null;
            else
                return new ValidationResult("Debe elegir un día al menos");
        }

    }

}

