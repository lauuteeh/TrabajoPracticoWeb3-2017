using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Reserva(int idPelicula)
        {
            myContext ctx = new myContext();

            var a = ctx.Peliculas.Where(x => x.IdPelicula == idPelicula);

            //Temporal
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Español", Value = "1" });
            li.Add(new SelectListItem { Text = "Subtitulado", Value = "2" });
            ViewData["version"] = li;
            return View(a);
        }


        //Ejemplo de select en cascada
        public JsonResult GetStates(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    states.Add(new SelectListItem { Text = "Seleccione", Value = "0" });
                    states.Add(new SelectListItem { Text = "La Matanza", Value = "1" });
                    states.Add(new SelectListItem { Text = "Belgrano", Value = "2" });
                    break;
                case "2":
                    states.Add(new SelectListItem { Text = "Seleccione", Value = "0" });
                    states.Add(new SelectListItem { Text = "Recoleta", Value = "4" });
                    states.Add(new SelectListItem { Text = "Caballito", Value = "3" });
                    break;
            }
            return Json(new SelectList(states, "Value", "Text"));
        }

        public JsonResult GetCity(string id)
        {
            List<SelectListItem> City = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "Lunes", Value = "1" });
                    break;
                case "2":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "Martes", Value = "2" });
                    break;
                case "3":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "Miercoles", Value = "3" });
                    break;
                case "4":
                    City.Add(new SelectListItem { Text = "Select", Value = "0" });
                    City.Add(new SelectListItem { Text = "Jueves", Value = "4" });
                    break;
            }

            return Json(new SelectList(City, "Value", "Text"));
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