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
        //Listado de peliculas
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
        //Accion que persiste los datos en la bdd
        [HttpPost]
        public ActionResult AltaPelicula(Peliculas pelicula, HttpPostedFileBase file)
        {
            myContext ctx = new myContext();//Instancio el contexto
            if (ModelState.IsValid)
            { 
                pelicula.FechaCarga = DateTime.Now;
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
                return View("Peliculas", a);
            }
            var e = (ctx.Generos).ToList();
            ViewBag.Generos = e;
            var f = (ctx.Calificaciones).ToList();
            ViewBag.Calificaciones = f;
            return View();
        }
        //Redirecciona y envía model
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
        //Persiste los cambios en bdd
        [HttpPost]
        public ActionResult editarPelicula(Peliculas peli, HttpPostedFileBase file)
        {
            myContext ctx = new myContext();//Instancio el contexto

                var id = Int32.Parse(Request.Form["id"]);
                Peliculas peli2 = (from pel in ctx.Peliculas where pel.IdPelicula == id select pel).First();

                if (file != null && file.ContentLength > 0) // Agregar IMAGEN
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        peli.Imagen = Path.GetFileName(file.FileName);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                else
                {
                    peli.Imagen = Request.Form["Imagen"];
                }
                peli2.Nombre = peli.Nombre;
                peli2.Descripcion = peli.Descripcion;
                peli2.Duracion = peli.Duracion;
                peli2.FechaCarga = DateTime.Now;
                peli2.IdGenero = Int32.Parse(Request.Form["Generos"]);
                peli2.IdCalificacion = Int32.Parse(Request.Form["Calificaciones"]);
                ctx.SaveChanges();//persisto los datos en la bdd
                var a = (ctx.Peliculas).ToList();//Cargo el modelo para Peliculas
                return View("Peliculas", a);
            }

        /* Las peliculas no deben eliminarse
        public ActionResult eliminarPelicula()
        {
            myContext ctx = new myContext();
            var idPeli = Int32.Parse(Request.QueryString["id"]);
            Peliculas peli = (from pe in ctx.Peliculas where pe.IdPelicula == idPeli select pe).First();
            ctx.Peliculas.Remove(peli);
            ctx.SaveChanges();
            var a = (ctx.Peliculas).ToList();//Cargo el modelo para Peliculas
            return View("Peliculas",a);
        }*/
        //Listado de Sedes
        public ActionResult Sedes()
        {
            myContext ctx = new myContext();
            var a = (ctx.Sedes).ToList();
            return View(a);
        }
        //Accion para redireccionar a la vista para agragar una nueva sede
        public ActionResult AltaSede()
        {
            return View();
        }
        //Acción que persiste los datos en la bdd
        [HttpPost]
        public ActionResult AltaSede(Sedes sede)
        {
            if (ModelState.IsValid)
            {
                myContext ctx = new myContext();
                sede.PrecioGeneral = Decimal.Parse(Request.Form["precioGeneral"]);
                ctx.Sedes.Add(sede);
                ctx.SaveChanges();
                var a = (ctx.Sedes).ToList();
                return View("Sedes", a);
            }
            return View();
        }
        //Redirecciona a EditarSede y le envía el model
        public ActionResult EditarSede()
        {
            myContext ctx = new myContext();
            if (ModelState.IsValid)
            {
                var id = Int32.Parse(Request.QueryString["id"]);
                var a = (from se in ctx.Sedes where se.IdSede == id select se).ToList();

                return View(a);
            }
            return View();
        }
        //Persiste los cambios en la bdd
        [HttpPost]
        public ActionResult EditarSede(Sedes sede)
        {
            myContext ctx = new myContext();
            var precio = Decimal.Parse(Request.Form["PrecioGeneral"]);
            Sedes sedeOrig = (from se in ctx.Sedes where se.IdSede == sede.IdSede select se).First();

            sedeOrig.Nombre = sede.Nombre;
            sedeOrig.PrecioGeneral = precio;
            sedeOrig.Direccion = sede.Direccion;
            ctx.SaveChanges();
            var a = (ctx.Sedes).ToList();
            return View("Sedes", a);
        }
        /*Lase sedes no deben eliminarse
        public ActionResult EliminarSede()
        {
            myContext ctx = new myContext();
            var id = Int32.Parse(Request.QueryString["id"]);
            Sedes sede = (from se in ctx.Sedes where se.IdSede == id select se).First();
            ctx.Sedes.Remove(sede);
            ctx.SaveChanges();
            var a = (ctx.Sedes).ToList();//Cargo el modelo para Peliculas
            
            return View("Sedes", a);
        }*/

        public ActionResult Carteleras()
        {
            myContext ctx = new myContext();
            var a = (ctx.Carteleras).ToList();
            var b = (ctx.Sedes).ToList();
            var c = (ctx.Peliculas).ToList();
            var d = (ctx.Versiones).ToList();

            ViewBag.Sedes = b;
            ViewBag.Peli = c;
            ViewBag.Version = d; 

            return View(a);
        }

        //Accion para redireccionar a la vista para agragar una nueva cartelera
        public ActionResult AltaCartelera()
        {
            myContext ctx = new myContext();
            var b = (ctx.Sedes).ToList();
            var c = (ctx.Peliculas).ToList();
            var d = (ctx.Versiones).ToList();

            ViewBag.Sedes = b;
            ViewBag.Peli = c;
            ViewBag.Version = d;
            return View();
        }
        [HttpPost]
        public ActionResult AltaCartelera(Carteleras cartelera)
        {
            myContext ctx = new myContext();
            cartelera.IdPelicula = Int32.Parse(Request.Form["Peliculas"]);
            cartelera.IdSede = Int32.Parse(Request.Form["Sedes"]);
            cartelera.IdVersion = Int32.Parse(Request.Form["Versiones"]);
            var asd = Convert.ToDateTime(Request.Form["HoraInicio"]);
            var asd2 = (asd.Hour).ToString();
            var asd3 = (asd.Minute).ToString();
            cartelera.HoraInicio = Int32.Parse(asd2+asd3);
            cartelera.FechaCarga = DateTime.Now;
      
            var dias = Request.Form["chk_group[]"];
            
                foreach(var dia in dias)
            {
                if (dia == '1') { cartelera.Lunes = true; }
                if (dia == '2') { cartelera.Martes = true; }
                if (dia == '3') { cartelera.Miercoles = true; }
                if (dia == '4') { cartelera.Jueves = true; }
                if (dia == '5') { cartelera.Viernes = true; }
                if (dia == '6') { cartelera.Sabado = true; }
                if (dia == '7') { cartelera.Domingo = true; }

            }

            ctx.Carteleras.Add(cartelera);
            ctx.SaveChanges();
            //Preparo lo necesario para devolver la vista Carteleras
            var b = (ctx.Sedes).ToList();
            var c = (ctx.Peliculas).ToList();
            var d = (ctx.Versiones).ToList();
            ViewBag.Sedes = b;
            ViewBag.Peli = c;
            ViewBag.Version = d;
            var a = (ctx.Carteleras).ToList();
            return View("Carteleras",a);
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