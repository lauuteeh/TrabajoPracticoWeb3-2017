﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TrabajoPracticoWeb3.App_Data;
using TrabajoPracticoWeb3.Models;

namespace TrabajoPracticoWeb3.Controllers
{
    [Autenticado]
    public class AdministracionController : Controller
    {
        // Si no estamos logeado, regresamos al login
        public class AutenticadoAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);

                //obtiene la url anterior
                var url = filterContext.HttpContext.Request.RawUrl;

                if (!UsuarioServicio.ExisteUsuarioEnSesion())
                {
                    //ingresa la url en una variable de sesion
                    System.Web.HttpContext.Current.Session["UrlAnterior"] = url;
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        url,
                        controller = "Home",
                        action = "Login"
                    }));
                }
            }
        }

        // Si estamos logeado ya no podemos acceder a la página de Login
        public class NoLoginAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);

                if (UsuarioServicio.ExisteUsuarioEnSesion())
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Administracion",
                        action = "Inicio"
                    }));
                }
            }
        }

        public AdministracionController()
        {
            //crear aca el contexto
        }

        // GET: Administracion
        public ActionResult Inicio()
        {
            ViewBag.NombreUsuario = Session["Usuario"];
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
        public ActionResult AltaPelicula(Peliculas pelicula, HttpPostedFileBase Imagen)
        {
            myContext ctx = new myContext();//Instancio el contexto
            if (ModelState.IsValid)
            {
                var file = Imagen;
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
            var a = (from peli in ctx.Peliculas where peli.IdPelicula == idPeli select peli).FirstOrDefault();

            ViewBag.Generos = AdministracionServicio.GetGeneros();
            ViewBag.Calificaciones = AdministracionServicio.GetCalificaciones();
            return View(a);
        }
        //Persiste los cambios en bdd
        [HttpPost]
        public ActionResult editarPelicula(Peliculas peli, HttpPostedFileBase image)
        {
            myContext ctx = new myContext();//Instancio el contexto
            if (ModelState.IsValid)
            {
                var file = image;
                var id = Int32.Parse(Request.Form["idPelicula"]);
                Peliculas peli2 = (from pel in ctx.Peliculas where pel.IdPelicula == id select pel).FirstOrDefault();

                if (file != null && file.ContentLength > 0) // Agregar IMAGEN
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        peli2.Imagen = Path.GetFileName(file.FileName);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                else
                {
                    if (peli2.Imagen != Request.Form["Imagen"] && Request.Form["Imagen"] != "" && Request.Form["Imagen"] != null)
                    {
                        //string path = Path.Combine(Server.MapPath("~/Images"),
                        //          Path.GetFileName(Request.Form["Imagen"]));
                        //file.SaveAs(path);
                        //peli.Imagen = Path.GetFileName(Request.Form["Imagen"]);
                        peli2.Imagen = Request.Form["Imagen"];

                    }
                }
                peli2.Nombre = peli.Nombre;
                peli2.Descripcion = peli.Descripcion;
                peli2.Duracion = peli.Duracion;
                peli2.FechaCarga = DateTime.Now;
                peli2.IdGenero = peli.IdGenero;
                peli2.IdCalificacion = peli.IdCalificacion;
                ctx.SaveChanges();//persisto los datos en la bdd
                var a = (ctx.Peliculas).ToList();//Cargo el modelo para Peliculas
                return View("Peliculas", a);
            }

            ViewBag.Generos = AdministracionServicio.GetGeneros();
            ViewBag.Calificaciones = AdministracionServicio.GetCalificaciones();

            return View(peli);
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
                var a = (from se in ctx.Sedes where se.IdSede == id select se).FirstOrDefault();
                return View(a);
            }
            return View();
        }
        //Persiste los cambios en la bdd
        [HttpPost]
        public ActionResult EditarSede(Sedes sede)
        {
            myContext ctx = new myContext();
            if (ModelState.IsValid)
            {
                Sedes sedeOrig = (from se in ctx.Sedes where se.IdSede == sede.IdSede select se).FirstOrDefault();
                sedeOrig.Nombre = sede.Nombre;
                sedeOrig.Direccion = sede.Direccion;
                sedeOrig.PrecioGeneral = sede.PrecioGeneral;
                ctx.SaveChanges();

                var a = (ctx.Sedes).ToList();
                return View("Sedes", a);
            }
            return View();


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
            if (ModelState.IsValid)
            {
                ViewBag.Mensaje = "";
                cartelera.FechaCarga = DateTime.Now;
                //var dias = Request.Form["chk_group[]"];
                //foreach (var dia in dias)
                //{
                //    if (dia == '1') { cartelera.Lunes = true; }
                //    if (dia == '2') { cartelera.Martes = true; }
                //    if (dia == '3') { cartelera.Miercoles = true; }
                //    if (dia == '4') { cartelera.Jueves = true; }
                //    if (dia == '5') { cartelera.Viernes = true; }
                //    if (dia == '6') { cartelera.Sabado = true; }
                //    if (dia == '7') { cartelera.Domingo = true; }
                //}

                var sede = (ctx.Sedes).ToList();
                var peli = (ctx.Peliculas).ToList();
                var version = (ctx.Versiones).ToList();
                ViewBag.Sedes = sede;
                ViewBag.Peli = peli;
                ViewBag.Version = version;

                if (AdministracionServicio.ValidaCartelera(cartelera))
                {
                    ctx.Carteleras.Add(cartelera);
                    ctx.SaveChanges();
                    //Preparo lo necesario para devolver la vista Carteleras

                    var a = (ctx.Carteleras).ToList();
                    return View("Carteleras", a);
                }
                else
                {
                    ViewBag.Mensaje = "ATENCIÓN !!! La cartelera ingresada no se encuentra disponible en las fechas: " + cartelera.FechaInicio + " - " + cartelera.FechaFin;
                    return View();
                }


            }
            var b = (ctx.Sedes).ToList();
            var c = (ctx.Peliculas).ToList();
            var d = (ctx.Versiones).ToList();

            ViewBag.Sedes = b;
            ViewBag.Peli = c;
            ViewBag.Version = d;
            return View();
        }

        public ActionResult EliminarCartelera()
        {
            myContext ctx = new myContext();
            var idCart = Int32.Parse(Request.QueryString["id"]);
            Carteleras cart = (from pe in ctx.Carteleras where pe.IdCartelera == idCart select pe).First();
            ctx.Carteleras.Remove(cart);
            ctx.SaveChanges();
            var a = (ctx.Carteleras).ToList();//Cargo el modelo para Peliculas
            var b = (ctx.Sedes).ToList();
            var c = (ctx.Peliculas).ToList();
            var d = (ctx.Versiones).ToList();

            ViewBag.Sedes = b;
            ViewBag.Peli = c;
            ViewBag.Version = d;
            return View("Carteleras", a);
        }

        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult ListaReportes()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            UsuarioServicio.CerrarSesion();
            return RedirectToAction("Login", "Home");
        }



    }
}