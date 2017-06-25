//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrabajoPracticoWeb3.App_Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Peliculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peliculas()
        {
            this.Carteleras = new HashSet<Carteleras>();
            this.Reservas = new HashSet<Reservas>();
        }

        public int IdPelicula { get; set; }
        [Required(ErrorMessage = "¡Se requiere un nombre de pelicula!")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "¡Por favor ingresar una Descripción!")]
        public string Descripcion { get; set; }

        public string Imagen { get; set; }
        [Required(ErrorMessage = "¡Por favor, Seleccionar una calificacion!")]
        public int IdCalificacion { get; set; }
        [Required(ErrorMessage = "¡Por favor, Seleccionar un genero!")]
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "¡Por favor, ingresar la duración!")]
        [Range(1, 90, ErrorMessage = "El rango de duración es de 1 a 90 minutos")]
        public int Duracion { get; set; }
        public System.DateTime FechaCarga { get; set; }

        public virtual Calificaciones Calificaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carteleras> Carteleras { get; set; }
        public virtual Generos Generos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
