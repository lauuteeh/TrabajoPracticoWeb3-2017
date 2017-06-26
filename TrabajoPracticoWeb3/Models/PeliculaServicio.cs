﻿using System;
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
                DiasItems.Add(new SelectListItem { Text = "Lunes", Value = "Lunes" });

            }

            var query2 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Martes == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query2.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Martes", Value = "Martes" });

            }

            var query3 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Miercoles == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query3.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Miercoles", Value = "Miercoles" });

            }

            var query4 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Jueves == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query4.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Jueves", Value = "Jueves" });

            }

            var query5 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Viernes == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query5.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Viernes", Value = "Viernes" });

            }

            var query6 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Sabado == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query6.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Sabado", Value = "Sabado" });

            }

            var query7 = ctx.Carteleras.Where(x => x.IdPelicula == IdPeliculaConvertido && x.IdVersion == IdVersionConvertido && x.IdSede == IdSedeConvertido && x.Domingo == true && x.FechaFin >= todaysDate && x.FechaInicio < todaysDate).Select(x => x.IdCartelera).ToList();
            if (query7.Count() > 0)
            {
                DiasItems.Add(new SelectListItem { Text = "Domingo", Value = "Domingo" });

            }

            SelectList Dias = new SelectList(DiasItems, "Value", "Text");

            return Dias;


        }

        public static SelectList MostrarHorarioCascada(string IdPelicula, string IdVersion, string IdSede)
        {


            myContext ctx = new myContext();


            int idPeliculaConvertido, idSedeConvertido, idVersionConvertido;

            Int32.TryParse(IdPelicula, out idPeliculaConvertido);
            Int32.TryParse(IdSede, out idSedeConvertido);
            Int32.TryParse(IdVersion, out idVersionConvertido);

            var Cartelera = ctx.Carteleras.Where(x => x.IdPelicula == idPeliculaConvertido && x.IdSede == idSedeConvertido && x.IdVersion == idVersionConvertido).First();

            List<SelectListItem> HorarioItems = new List<SelectListItem>();

            string HoraInicio = Cartelera.HoraInicio.ToString();
            int sitioDeCorte = 2;
            string parte1 = HoraInicio.Substring(0, sitioDeCorte);
            string parte2 = HoraInicio.Substring(sitioDeCorte);

            int HoraInicioParte1, HoraInicioParte2;

            Int32.TryParse(parte1, out HoraInicioParte1);
            Int32.TryParse(parte2, out HoraInicioParte2);

            TimeSpan Base = TimeSpan.FromHours(0);
            TimeSpan BaseComparar = TimeSpan.FromHours(0);

            TimeSpan HoraInicioResult1 = TimeSpan.FromHours(HoraInicioParte1);
            TimeSpan HoraInicioResult2 = TimeSpan.FromMinutes(HoraInicioParte2);
            TimeSpan HoraInicioCartelera = TimeSpan.FromHours(0);
            HoraInicioCartelera = HoraInicioResult1 + HoraInicioResult2;

            TimeSpan DuracionPelicula = TimeSpan.FromMinutes(Cartelera.Peliculas.Duracion);

            TimeSpan Intervalo = TimeSpan.FromMinutes(30);

            for (int i = 1; i < 8; i++)
            {


                if (Base == BaseComparar)
                {
                    Base = HoraInicioCartelera;
                }
                else
                {
                    Base = Base + DuracionPelicula;

                }


                string BaseString = Base.ToString("hh':'mm");
                HorarioItems.Add(new SelectListItem { Text = BaseString, Value = BaseString });

                Base = Base + Intervalo;

            }

            SelectList Horarios = new SelectList(HorarioItems, "Value", "Text");

            return Horarios;

        }

        public static dynamic TraeTiposDeDocumentos()
        {
            myContext ctx = new myContext();
            var tiposDoc = ctx.TiposDocumentos;

            return tiposDoc;
        }


    }
}