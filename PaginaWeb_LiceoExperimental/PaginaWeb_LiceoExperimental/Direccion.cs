//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaginaWeb_LiceoExperimental
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direccion
    {
        public long DireccionID { get; set; }
        public string Linea1 { get; set; }
        public string Linea2 { get; set; }
        public byte Prioridad { get; set; }
        public byte TipoDireccionID { get; set; }
        public short UbicacionGeograficaID { get; set; }
    
        public virtual TipoDireccion TipoDireccion { get; set; }
        public virtual UbicacionGeografica UbicacionGeografica { get; set; }
    }
}
