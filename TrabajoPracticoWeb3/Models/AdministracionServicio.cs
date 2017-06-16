using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class AdministracionServicio
    {
        private static myContext ctx;

        public static SelectList GetGeneros()
        {
            ctx = new myContext();
            var b = (ctx.Generos).ToList();
            var generos = b
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.IdGenero.ToString(),
                                    Text = x.Nombre
                                });
            return new SelectList(generos, "Value", "Text");
        }

        public static SelectList GetCalificaciones()
        {
            ctx = new myContext();
            var c = (ctx.Calificaciones).ToList();
            var calificaciones = c
                       .Select(x =>
                               new SelectListItem
                               {
                                   Value = x.IdCalificacion.ToString(),
                                   Text = x.Nombre
                               });
            return new SelectList(calificaciones, "Value", "Text"); ;
        }
    }
}