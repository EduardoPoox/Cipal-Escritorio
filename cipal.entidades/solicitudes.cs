//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cipal.entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class solicitudes
    {
        public int idsolicitud { get; set; }
        public string folio { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> iddepartamento { get; set; }
        public Nullable<int> idempleado { get; set; }
        public string comentarios { get; set; }
        public Nullable<int> iddocumentodigital { get; set; }
        public string usuario { get; set; }
        public Nullable<System.DateTime> fechacreacion { get; set; }
        public Nullable<bool> baja { get; set; }
    }
}