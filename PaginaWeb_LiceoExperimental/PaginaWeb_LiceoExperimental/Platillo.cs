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
    
    public partial class Platillo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platillo()
        {
            this.CategoriaPlatillo = new HashSet<CategoriaPlatillo>();
            this.PlatilloDia = new HashSet<PlatilloDia>();
        }
    
        public System.Guid ID { get; set; }
        public int PlatilloID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Habilitado { get; set; }
        public byte[] Fotografia { get; set; }
        public int PrecioID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriaPlatillo> CategoriaPlatillo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatilloDia> PlatilloDia { get; set; }
        public virtual Precio Precio { get; set; }
    }
}