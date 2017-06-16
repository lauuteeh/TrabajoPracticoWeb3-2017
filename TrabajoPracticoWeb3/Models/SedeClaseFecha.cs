using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class SedeClaseFecha : ValidationAttribute
    {
        public SedeClaseFecha(String NumeroSala, String FechaInicio, String pelicula)
        {
            this.fechaI = FechaInicio;
            this.pelis = pelicula;
            this.Num = NumeroSala;
        }

        public String pelis { get; private set; }
        public String fechaI { get; private set; }
        public String Num { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            myContext ctx = new myContext();
            var carteleras = (ctx.Carteleras).ToList();
            var cart2 = (Carteleras)validationContext.ObjectInstance;
            var FI = DateTime.Parse(fechaI);
            var Num2 = Int32.Parse(Num);
            var Peli = Int32.Parse(pelis);
                foreach (var ct in carteleras)
                {
                    if (FI == ct.FechaInicio)
                    {
                        if (Num2 == ct.NumeroSala)
                        {
                            if(Peli == ct.IdPelicula) { 
                            return new ValidationResult(validationContext.DisplayName + " Ya existe una cartelera con las mismas condiciones.");
                             }
                        }
                    }
                }
            
                    
            
            // Ok!
            return ValidationResult.Success;
        }
    }
}