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
    
    public partial class detapoyos
    {
        public int idapoyo { get; set; }
        public int iddetapoyo { get; set; }
        public Nullable<int> idconcepto { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> idunidad { get; set; }
        public string usuario { get; set; }
        public Nullable<System.DateTime> fechacreacion { get; set; }
        public Nullable<bool> baja { get; set; }
    }
}