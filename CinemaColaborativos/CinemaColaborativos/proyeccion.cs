//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaColaborativos
{
    using System;
    using System.Collections.Generic;
    
    public partial class proyeccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proyeccion()
        {
            this.reservacion = new HashSet<reservacion>();
        }
    
        public int id_proyeccion { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public Nullable<bool> estado_proyeccion { get; set; }
        public int pelicula_id_pelicula { get; set; }
        public int sala_id_sala { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaFinal { get; set; }
    
        public virtual pelicula pelicula { get; set; }
        public virtual sala sala { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservacion> reservacion { get; set; }
    }
}
