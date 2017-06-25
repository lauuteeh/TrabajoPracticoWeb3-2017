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
            return View();
        }

        public ActionResult ConfirmarReserva()
        {
            return View();
        }


    }
}