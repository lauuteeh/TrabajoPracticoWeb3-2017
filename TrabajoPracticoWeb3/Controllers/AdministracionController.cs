using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;


namespace TrabajoPracticoWeb3.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Peliculas()
        {
            myContext ctx = new myContext();
            var a = (ctx.Peliculas).ToList();//(from peliculas in ctx.Peliculas select peliculas).ToList(); 
            return View(a);
        }

        //Accion para redireccionar a la vista para agragar una nueva pelicula
        public ActionResult AltaPelicula()
        {
            myContext ctx = new myContext();
            var a = (ctx.Generos).ToList();
            ViewBag.Generos = a;
            var b = (ctx.Calificaciones).ToList();
            ViewBag.Calificaciones = b;
            return View();
        }
        [HttpPost]
        public ActionResult AltaPelicula(Peliculas pelicula)
        {
            myContext ctx = new myContext();//Instancio el contexto
            pelicula.IdGenero = Int32.Parse(Request.Form["Generos"]);
            pelicula.IdCalificacion = Int32.Parse(Request.Form["Calificaciones"]);
            ctx.Peliculas.Add(pelicula);//Agrego la pelicula traida por post
            ctx.SaveChanges();//persisto los datos en la bdd
            var a = (ctx.Peliculas).ToList();
            return View("Peliculas",a);
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