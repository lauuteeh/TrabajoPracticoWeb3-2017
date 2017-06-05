using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult Cartelera()
        {
            return View();
        }

        public ActionResult Proximamente()
        {
            return View();
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