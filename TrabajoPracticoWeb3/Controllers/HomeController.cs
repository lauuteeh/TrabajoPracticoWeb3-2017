﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Pelicula()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}