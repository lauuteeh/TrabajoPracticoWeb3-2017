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
    
    public partial class Calificaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calificaciones()
        {
            this.Peliculas = new HashSet<Peliculas>();
        }
    
        public int IdCalificacion { get; set; }
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Peliculas> Peliculas { get; set; }

        public static implicit operator Calificaciones(string v)
        {
            throw new NotImplementedException();
        }
    }
}
