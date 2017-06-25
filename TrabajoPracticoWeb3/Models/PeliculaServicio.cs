using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class PeliculaServicio
    {

        public static dynamic TraerPelicula(int IdPelicula)
        {

            myContext ctx = new myContext();
            var Pelicula = ctx.Peliculas.Where(x => x.IdPelicula == IdPelicula);

            return Pelicula;
        }

        public static SelectList MostrarVersionCascada(int IdPelicula)
        {

            DateTime todaysDate = DateTime.Now;

            myContext ctx = new myContext();

            IEnumerable<SelectListItem> VersionesItems = ctx.Carteleras.AsEnumerable().Where(x => x.IdPelicula == IdPelicula && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).GroupBy(i => i.IdVersion).Select(group => group.First()).Select(c => new SelectListItem()
            {
                Text = c.Versiones.Nombre,
                Value = c.IdVersion.ToString(),
                Selected = true,
            });

            SelectList Versiones = new SelectList(VersionesItems, "Value", "Text");

            return Versiones;

        }


        public static SelectList MostrarSedeCascada(string IdPelicula, string IdVersion)
        {

            myContext ctx = new myContext();
            DateTime todaysDate = DateTime.Now;

            int IdVersionConvertido, IdPeliculaConvertido;

            Int32.TryParse(IdVersion, out IdVersionConvertido);
            Int32.TryParse(IdPelicula, out IdPeliculaConvertido);

            IEnumerable<SelectListItem> SedesItems = ctx.Carteleras.AsEnumerable().Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).GroupBy(i => i.IdSede).Select(group => group.First()).Select(c => new SelectListItem()
            {
                Text = c.Sedes.Nombre,
                Value = c.IdSede.ToString(),
                Selected = true,
            });

            SelectList Sedes = new SelectList(SedesItems, "Value", "Text");

            return Sedes;
        }


        public static SelectList MostrarDiaCascada(string IdPelicula, string IdVersion, string IdSede)
        {

            myContext ctx = new myContext();
            DateTime todaysDate = DateTime.Now;

            int IdSedeConvertido, IdPeliculaConvertido, IdVersionConvertido;

            Int32.TryParse(IdSede, out IdSedeConvertido);
            Int32.TryParse(IdPelicula, out IdPeliculaConvertido);
            Int32.TryParse(IdVersion, out IdVersionConvertido);


            List<SelectListItem> DiasItems = new List<SelectListItem>();

            var query = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Lunes == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Lunes", Value = "1" });

            }

            var query2 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Martes == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query2.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Martes", Value = "2" });

            }

            var query3 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Miercoles == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query3.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Miercoles", Value = "3" });

            }

            var query4 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Jueves == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query4.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Jueves", Value = "4" });

            }

            var query5 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Viernes == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query5.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Viernes", Value = "5" });

            }

            var query6 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Sabado == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query6.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Sabado", Value = "6" });

            }

            var query7 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Domingo == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query7.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Domingo", Value = "7" });

            }

            SelectList Dias = new SelectList(DiasItems, "Value", "Text");

            return Dias;


        }
    }
}