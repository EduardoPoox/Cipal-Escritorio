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
    
    public partial class impuestos
    {
        public int idimpuesto { get; set; }
        public string tipoimpuesto { get; set; }
        public string cveimpuesto { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> tasa { get; set; }
        public int idorigen { get; set; }
        public string usuario { get; set; }
        public Nullable<bool> baja { get; set; }
    }
}
