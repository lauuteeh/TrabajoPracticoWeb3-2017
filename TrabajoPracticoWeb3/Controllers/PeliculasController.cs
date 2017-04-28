using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabajoPracticoWeb3.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Reserva()
        {
            return View();
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