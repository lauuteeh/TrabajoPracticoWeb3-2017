using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabajoPracticoWeb3.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Peliculas()
        {
            return View();
        }

        //Accion para redireccionar a la vista para agragar una nueva pelicula
        public ActionResult AltaPelicula()
        {
            return View();
        }

        public ActionResult Sedes()
        {
            return View();
        }

        //Accion para redireccionar a la vista para agragar una nueva sede
        public ActionResult AltaSede()
        {
            return View();
        }

        public ActionResult Carteleras()
        {
            return View();
        }

        //Accion para redireccionar a la vista para agragar una nueva cartelera
        public ActionResult AltaCartelera()
        {
            return View();
        }

        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult ListaReportes()
        {
            return View();
        }

    }
}