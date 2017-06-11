using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class HomeServicios
    {

        public static dynamic CarteleraActual() {

            myContext ctx = new myContext();
            DateTime todaysDate = DateTime.Now;

            var a = (from cartelera in ctx.Carteleras where cartelera.FechaFin >= todaysDate && cartelera.FechaInicio < todaysDate select cartelera).ToList(); ;

            return a;

        }

        public static dynamic CarteleraProximamente()
        {

            myContext ctx = new myContext();
            DateTime todaysDate = DateTime.Now;
            DateTime OneMoreMonth = DateTime.Now.Date.AddMonths(1);
            var a = (from cartelera in ctx.Carteleras where cartelera.FechaInicio > todaysDate && cartelera.FechaInicio < OneMoreMonth select cartelera).ToList(); ;

            return a;

        }
    }
}