using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPracticoWeb3.App_Data;
using TrabajoPracticoWeb3.Models;

namespace TrabajoPracticoWeb3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var a = HomeServicios.CarteleraActual();
            return View(a);
        }

        public ActionResult GetImage(string image)
        {
            string path = Server.MapPath("~/Images/" + image);
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            return File(imageByteData, "image/jpg");
        }

        public ActionResult Cartelera()
        {
            var a = HomeServicios.CarteleraActual();
            return View(a);
        }

        public ActionResult Proximamente()
        {
            var a = HomeServicios.CarteleraProximamente();
            return View(a);
        }      

        public ActionResult Login()
        {
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                var usuario = UsuarioServicio.IniciarSesion(u);
                //obtiene la url traida con la session
                var urlAnterior = System.Web.HttpContext.Current.Session["UrlAnterior"] as String;
                if (usuario != null)
                {
                    var action = "Inicio";
                    var controller = "Administracion";

                    UsuarioServicio.AgregarUsuarioASesion(usuario.NombreUsuario);
                    Session["Usuario"] = usuario.NombreUsuario;

                    //Verifica si el viewdata no es nulo
                    if (urlAnterior != null)
                    {
                        var urlArray = urlAnterior.ToString().Trim('/').Split('/');
                        if (urlArray.Count() == 2)
                        {
                            controller = urlArray[0].ToString();
                            action = urlArray[1].ToString();
                        }
                    }
                    return RedirectToAction(action, controller);
                }
                else
                {
                    ViewBag.Mensaje = "Usuario y/o Contraseña invalidos";
                }
            }
            return View("Login");
        }

    }
}