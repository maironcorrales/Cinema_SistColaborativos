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
    
    public partial class factura
    {
        public int id_factura { get; set; }
        public string fecha { get; set; }
        public decimal monto { get; set; }
        public string descripcion { get; set; }
        public int reservacion_id_reservacion { get; set; }
        public int reservacion_usuario_id_usuario { get; set; }
    
        public virtual reservacion reservacion { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
