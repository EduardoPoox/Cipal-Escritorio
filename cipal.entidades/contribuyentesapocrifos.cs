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
    
    public partial class contribuyentesapocrifos
    {
        public int idcontribuyenteapocrifo { get; set; }
        public string rfc { get; set; }
        public string nombre { get; set; }
        public string situacion { get; set; }
        public string oficiosat { get; set; }
        public Nullable<System.DateTime> fechasat { get; set; }
        public string oficiodof { get; set; }
        public Nullable<System.DateTime> fechadof { get; set; }
        public string usuario { get; set; }
        public Nullable<bool> baja { get; set; }
    }
}