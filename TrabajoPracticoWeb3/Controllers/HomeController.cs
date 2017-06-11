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
            string path = Server.MapPath("~/Images/"+image);
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

        public ActionResult Ubicacion()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult IniciarSesion(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                var usuario = UsuarioServicio.IniciarSesion(u);
                if (usuario != null)
                {
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Inicio", "Administracion");
                }
            }
            return View("Login");
        }

    }
}