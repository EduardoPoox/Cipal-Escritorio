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
    
    public partial class documentosdigitalesimpuestos
    {
        public int iddocumentodigitalimpuesto { get; set; }
        public Nullable<int> iddocumentodigital { get; set; }
        public Nullable<int> iddocumentodigitalconcepto { get; set; }
        public string tipoimpuesto { get; set; }
        public Nullable<decimal> baseimpuesto { get; set; }
        public string impuesto { get; set; }
        public string tipofactor { get; set; }
        public Nullable<decimal> tasaocuota { get; set; }
        public Nullable<decimal> importe { get; set; }
        public Nullable<bool> baja { get; set; }
    }
}
