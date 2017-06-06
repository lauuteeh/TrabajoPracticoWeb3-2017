using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AltaPelicula(Peliculas pelicula, HttpPostedFileBase file)
        {
            myContext ctx = new myContext();//Instancio el contexto
            pelicula.IdGenero = Int32.Parse(Request.Form["Generos"]);
            pelicula.IdCalificacion = Int32.Parse(Request.Form["Calificaciones"]);
            ctx.Peliculas.Add(pelicula);//Agrego la pelicula traida por post

            if (file != null && file.ContentLength > 0) // Agregar IMAGEN
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    pelicula.Imagen = Path.GetFileName(file.FileName);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "No especificó una imagen";
            }

            ctx.SaveChanges();//persisto los datos en la bdd
            var a = (ctx.Peliculas).ToList();//Cargo el modelo para Peliculas
            return View("Peliculas",a);
        }
        public ActionResult editarPelicula()
        {
            myContext ctx = new myContext();
            var idPeli = Int32.Parse(Request.QueryString["id"]);
            var a = (from peli in ctx.Peliculas where peli.IdPelicula == idPeli select peli).ToList();
            var b = (ctx.Generos).ToList();
            ViewBag.Generos = b;
            var c = (ctx.Calificaciones).ToList();
            ViewBag.Calificaciones = c;
            return View(a);
        }
        [HttpPost]
        public ActionResult editarPelicula(Peliculas pelicula, HttpPostedFileBase file)
        {
            myContext ctx = new myContext();//Instancio el contexto
            pelicula.IdGenero = Int32.Parse(Request.Form["Generos"]);
            pelicula.IdCalificacion = Int32.Parse(Request.Form["Calificaciones"]);
            var id = Int32.Parse(Request.Form["idPelicula"]);
            Peliculas peli = (from pel in ctx.Peliculas where pel.IdPelicula == id select pel).First();

            if (file != null && file.ContentLength > 0) // Agregar IMAGEN
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    pelicula.Imagen = Path.GetFileName(file.FileName);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                pelicula.Imagen = Request.Form["Imagen"];
            }
            peli.Nombre = pelicula.Nombre;
            peli.Descripcion = pelicula.Descripcion;
            peli.Duracion = pelicula.Duracion;
            peli.FechaCarga = pelicula.FechaCarga;
            peli.IdGenero = pelicula.IdGenero;
            peli.IdCalificacion = pelicula.IdCalificacion;
            ctx.SaveChanges();//persisto los datos en la bdd
            var a = (ctx.Peliculas).ToList();//Cargo el modelo para Peliculas
            return View("Peliculas", a);
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