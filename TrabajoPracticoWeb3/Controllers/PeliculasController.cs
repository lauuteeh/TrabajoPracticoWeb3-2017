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

        public JsonResult GetHorario(string id)
        {
            List<SelectListItem> City = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "10:00am", Value = "1" });
                    break;
                case "2":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "12:00am", Value = "2" });
                    break;
                case "3":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "14:00am", Value = "3" });
                    break;
                case "4":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "16:00am", Value = "4" });
                    break;
            }

            return Json(new SelectList(City, "Value", "Text"));
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