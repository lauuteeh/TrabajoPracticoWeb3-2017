using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;
using TrabajoPracticoWeb3.Models;

namespace TrabajoPracticoWeb3.Controllers
{
    public class ReporteReservasController : Controller
    {
        public ActionResult ReporteReservas(DateTime inicio, DateTime fin)
        {
            inicio = DateTime.Now;
            fin = DateTime.Now;
            myContext ctx = new myContext();

            var listSP = ctx.sp()
            var listReservas = (from r in ctx.Reservas
                                join s in ctx.Sedes on
                                r.IdSede equals s.IdSede
                                join v in ctx.Versiones on
                                r.IdVersion equals v.IdVersion
                                join p in ctx.Peliculas on
                                r.IdPelicula equals p.IdPelicula
                                where r.FechaHoraInicio > inicio && r.FechaHoraInicio < fin

                                select new { sedeNombre = s.Nombre, versionNombre = v.Nombre, peliculaNombre = p.Nombre, s.PrecioGeneral }
                                ).ToList();
            return View("ListadoReservas", listReservas);
            //return listReservas;
        }
    }
}