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
    
    public partial class Usuario
    {
        public long UsuarioID { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenna { get; set; }
        public byte Rol { get; set; }
        public bool Becado { get; set; }
        public bool Permisos { get; set; }
        public Nullable<long> PersonaID { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}
