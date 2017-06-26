using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;
using TrabajoPracticoWeb3.Models;

namespace TrabajoPracticoWeb3.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Reserva(int idPelicula)
        {
            myContext ctx = new myContext();

            var Pelicula = PeliculaServicio.TraerPelicula(idPelicula);

            SelectList Versiones = PeliculaServicio.MostrarVersionCascada(idPelicula);

            ViewData["version"] = Versiones;
            return View(Pelicula);
        }


        //Select en cascada
        public JsonResult GetSede(string idVersion, string idPelicula)
        {
            SelectList Sede = PeliculaServicio.MostrarSedeCascada(idPelicula, idVersion);

            return Json(Sede);
        }

        public JsonResult GetDia(string idSede, string idPelicula, string idVersion)
        {
            SelectList Dia = PeliculaServicio.MostrarDiaCascada(idPelicula, idVersion, idSede);

            return Json(Dia);
        }

        public JsonResult GetHorario(string idDia, string idSede, string idVersion, string idPelicula)
        {
            SelectList Horarios = PeliculaServicio.MostrarHorarioCascada(idPelicula, idVersion, idSede);

            return Json(Horarios);
        }


        public ActionResult FinalizarReserva()
        {
            myContext ctx = new myContext();
            ViewBag.Horario = Request["Horario"];
            ViewBag.Dia = Request["Dia"];

            int IdPelicula, IdSede, IdVersion;

            Int32.TryParse(Request["Pelicula"], out IdPelicula);
            Int32.TryParse(Request["Sede"], out IdSede);
            Int32.TryParse(Request["Version"], out IdVersion);

            var a = ctx.Carteleras.Where(x => x.IdPelicula == IdPelicula && x.IdSede == IdSede && x.IdVersion == IdVersion).First();

            
            return View(a);
        }
        [HttpPost]
        public ActionResult ConfirmarReserva()
        {
            myContext ctx = new myContext();
            Reservas reserva = new Reservas();

            int IdSede, IdPelicula, IdVersion, CantidadEntradas;

            Int32.TryParse(Request["IdPelicula"], out IdPelicula);
            Int32.TryParse(Request["IdSede"], out IdSede);
            Int32.TryParse(Request["IdVersion"], out IdVersion);
            Int32.TryParse(Request["CantidadEntradas"], out CantidadEntradas);


            string HoraInicio = Request["Horario"];
            int sitioDeCorte = 2;
            string parte1 = HoraInicio.Substring(0, sitioDeCorte);
            string parte2 = HoraInicio.Substring(sitioDeCorte);

            int HoraInicioParte1, HoraInicioParte2;

            Int32.TryParse(parte1, out HoraInicioParte1);
            Int32.TryParse(parte2, out HoraInicioParte2);
            DateTime Hora = DateTime.Today;


            Hora = Hora.AddHours(HoraInicioParte1);
            Hora = Hora.AddMinutes(HoraInicioParte2);


            reserva.IdPelicula = IdPelicula;
            reserva.IdVersion = IdVersion;
            reserva.IdSede = IdSede;
            reserva.FechaHoraInicio = Hora;
            reserva.FechaCarga = DateTime.Now;
            reserva.Email = Request["email"];
            reserva.IdTipoDocumento = 1;
            reserva.NumeroDocumento = Request["NumeroDocumento"];
            reserva.CantidadEntradas = CantidadEntradas;

            ctx.Reservas.Add(reserva);
            ctx.SaveChanges();


            return View();
        }


    }
}