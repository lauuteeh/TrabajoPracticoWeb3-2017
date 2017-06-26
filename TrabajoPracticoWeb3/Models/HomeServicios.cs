using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoPracticoWeb3.App_Data;

namespace TrabajoPracticoWeb3.Models
{
    public class HomeServicios
    {

        public static dynamic CarteleraActual()
        {
            myContext ctx = new myContext();

            DateTime todaysDate = DateTime.Now;            
            var a = ctx.Carteleras.Where(cartelera => cartelera.FechaFin >= todaysDate && cartelera.FechaInicio < todaysDate).GroupBy(x => x.IdPelicula).Select(group => group.FirstOrDefault());
            return a;

        }

        public static dynamic CarteleraProximamente()
        {
            myContext ctx = new myContext();

            DateTime todaysDate = DateTime.Now;
            DateTime OneMoreMonth = DateTime.Now.Date.AddMonths(1);
            var a = ctx.Carteleras.Where(cartelera => cartelera.FechaInicio > todaysDate && cartelera.FechaInicio < OneMoreMonth).GroupBy(x => x.IdPelicula).Select(group => group.FirstOrDefault());
            return a;

        }
    }
}