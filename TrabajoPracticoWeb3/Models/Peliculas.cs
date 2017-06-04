using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoPracticoWeb3.Models
{
    public class Peliculas
    {
        public int idPelicula { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string imagen { get; set; }
        public int idCalificacion { get; set; }
        public int idGenero { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaCarga { get; set; }
    }
}