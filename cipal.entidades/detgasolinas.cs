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
    
    public partial class detgasolinas
    {
        public int iddetgasolina { get; set; }
        public Nullable<int> idgasolina { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> kminicial { get; set; }
        public Nullable<decimal> kmfinal { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public Nullable<decimal> kmrecorridos { get; set; }
        public Nullable<decimal> litros { get; set; }
        public Nullable<decimal> pesos { get; set; }
        public string motivoviaje { get; set; }
        public Nullable<decimal> factor { get; set; }
        public string usuario { get; set; }
        public Nullable<bool> baja { get; set; }
    }
}
