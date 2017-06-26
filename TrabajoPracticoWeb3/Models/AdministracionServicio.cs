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

        public static bool ValidaCartelera(Carteleras cartelera)
        {
            ctx = new myContext();

            //Carteleras que se encuentran en el rango ingresado por la nueva cartelera
            var cartelerasPorFechas = ctx.Carteleras.Where(x => ((x.FechaInicio >= cartelera.FechaInicio && x.FechaInicio <= cartelera.FechaFin) ||
                     (x.FechaFin >= cartelera.FechaInicio && x.FechaFin <= cartelera.FechaFin) ||
                     (x.FechaInicio <= cartelera.FechaInicio && x.FechaFin >= cartelera.FechaFin)) &&
                     x.IdCartelera != cartelera.IdCartelera
                     );
            if (cartelerasPorFechas.Count() == 0)
                return true;

            //Comprobamos sedes en cartelera
            var sedes = cartelerasPorFechas.Where(x => x.IdSede == cartelera.IdSede);
            if (sedes.Count() == 0)
                return true;

            //Comprobamos sedes y sala en cartelera
            var sedesSala = sedes.Where(x => x.NumeroSala == cartelera.NumeroSala);
            if (sedesSala.Count() == 0)
                return true;

            //Comprobacion Dias
            var countDias = 0;
            if (cartelera.Lunes)
            {
                var lunes = sedesSala.Where(x => x.Lunes == cartelera.Lunes);
                countDias += lunes.Count();
            }
            if (cartelera.Martes)
            {
                var martes = sedesSala.Where(x => x.Martes == cartelera.Martes);
                countDias += martes.Count();
            }
            if (cartelera.Miercoles)
            {
                var miercoles = sedesSala.Where(x => x.Miercoles == cartelera.Miercoles);
                countDias += miercoles.Count();
            }
            if (cartelera.Jueves)
            {
                var jueves = sedesSala.Where(x => x.Jueves == cartelera.Jueves);
                countDias += jueves.Count();
            }
            if (cartelera.Viernes)
            {
                var viernes = sedesSala.Where(x => x.Viernes == cartelera.Viernes);
                countDias += viernes.Count();
            }
            if (cartelera.Sabado)
            {
                var sabado = sedesSala.Where(x => x.Sabado == cartelera.Sabado);
                countDias += sabado.Count();
            }
            if (cartelera.Domingo)
            {
                var domingo = sedesSala.Where(x => x.Domingo == cartelera.Domingo);
                countDias += domingo.Count();
            }

            return countDias == 0;
        }
    }
}