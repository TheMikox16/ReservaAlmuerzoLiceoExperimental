﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CocinaEntities : DbContext
    {
        public CocinaEntities()
            : base("name=CocinaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoriaPlatillo> CategoriaPlatillo { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<Platillo> Platillo { get; set; }
        public virtual DbSet<PlatilloDia> PlatilloDia { get; set; }
        public virtual DbSet<Precio> Precio { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<TipoCambio> TipoCambio { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<IdentificadorPersona> IdentificadorPersona { get; set; }
        public virtual DbSet<MecanismoDeContacto> MecanismoDeContacto { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidad { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<TipoDeTelefono> TipoDeTelefono { get; set; }
        public virtual DbSet<TipoIdentificadorPersona> TipoIdentificadorPersona { get; set; }
        public virtual DbSet<TipoMecanismoDeContacto> TipoMecanismoDeContacto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    
        public virtual int Agregar_Modificar_Platillo(Nullable<int> platilloID, string nombre, string descripcion, byte[] fotografia, Nullable<bool> habilitado)
        {
            var platilloIDParameter = platilloID.HasValue ?
                new ObjectParameter("PlatilloID", platilloID) :
                new ObjectParameter("PlatilloID", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var fotografiaParameter = fotografia != null ?
                new ObjectParameter("Fotografia", fotografia) :
                new ObjectParameter("Fotografia", typeof(byte[]));
    
            var habilitadoParameter = habilitado.HasValue ?
                new ObjectParameter("Habilitado", habilitado) :
                new ObjectParameter("Habilitado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Agregar_Modificar_Platillo", platilloIDParameter, nombreParameter, descripcionParameter, fotografiaParameter, habilitadoParameter);
        }
    
        public virtual int Agregar_Reserva(Nullable<bool> estado, Nullable<long> personaID)
        {
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var personaIDParameter = personaID.HasValue ?
                new ObjectParameter("PersonaID", personaID) :
                new ObjectParameter("PersonaID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Agregar_Reserva", estadoParameter, personaIDParameter);
        }
    
        public virtual ObjectResult<ConsultarReservas_PorFecha_Pendientes_Result> ConsultarReservas_PorFecha_Pendientes(Nullable<long> plato)
        {
            var platoParameter = plato.HasValue ?
                new ObjectParameter("Plato", plato) :
                new ObjectParameter("Plato", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarReservas_PorFecha_Pendientes_Result>("ConsultarReservas_PorFecha_Pendientes", platoParameter);
        }
    
        public virtual ObjectResult<ConsultarReservas_PorNombre_Result> ConsultarReservas_PorNombre(string nombre, Nullable<long> plato)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var platoParameter = plato.HasValue ?
                new ObjectParameter("Plato", plato) :
                new ObjectParameter("Plato", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarReservas_PorNombre_Result>("ConsultarReservas_PorNombre", nombreParameter, platoParameter);
        }
    
        public virtual ObjectResult<ConsultarReservasPorID_Result> ConsultarReservasPorID(string iD, Nullable<long> plato)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var platoParameter = plato.HasValue ?
                new ObjectParameter("Plato", plato) :
                new ObjectParameter("Plato", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarReservasPorID_Result>("ConsultarReservasPorID", iDParameter, platoParameter);
        }
    
        public virtual int EliminarPlatillo(Nullable<int> platilloID)
        {
            var platilloIDParameter = platilloID.HasValue ?
                new ObjectParameter("PlatilloID", platilloID) :
                new ObjectParameter("PlatilloID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarPlatillo", platilloIDParameter);
        }
    
        public virtual int EntregarPlatillo(Nullable<long> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EntregarPlatillo", iDParameter);
        }
    
        public virtual ObjectResult<ListaReserva_Result> ListaReserva(Nullable<long> plato)
        {
            var platoParameter = plato.HasValue ?
                new ObjectParameter("Plato", plato) :
                new ObjectParameter("Plato", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListaReserva_Result>("ListaReserva", platoParameter);
        }
    
        public virtual ObjectResult<ListarNoBecados_Result> ListarNoBecados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarNoBecados_Result>("ListarNoBecados");
        }
    
        public virtual ObjectResult<ListarNoBecados2_Result> ListarNoBecados2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarNoBecados2_Result>("ListarNoBecados2");
        }
    
        public virtual ObjectResult<ListarNoBecadosID_Result> ListarNoBecadosID(string iD)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarNoBecadosID_Result>("ListarNoBecadosID", iDParameter);
        }
    
        public virtual ObjectResult<ListarNoBecadosNombre_Result> ListarNoBecadosNombre(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarNoBecadosNombre_Result>("ListarNoBecadosNombre", nombreParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> PermisoReserva()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("PermisoReserva");
        }
    
        public virtual int SeleccionarPlatillo(Nullable<int> platilloID)
        {
            var platilloIDParameter = platilloID.HasValue ?
                new ObjectParameter("PlatilloID", platilloID) :
                new ObjectParameter("PlatilloID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SeleccionarPlatillo", platilloIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> VerificarBecado(Nullable<long> usuarioID)
        {
            var usuarioIDParameter = usuarioID.HasValue ?
                new ObjectParameter("UsuarioID", usuarioID) :
                new ObjectParameter("UsuarioID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("VerificarBecado", usuarioIDParameter);
        }
    
        public virtual ObjectResult<VerificarPlatoDia_Result> VerificarPlatoDia()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VerificarPlatoDia_Result>("VerificarPlatoDia");
        }
    
        public virtual ObjectResult<VerificarReserva_Result> VerificarReserva(Nullable<long> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VerificarReserva_Result>("VerificarReserva", iDParameter);
        }
    
        public virtual ObjectResult<ConsultarPlatoDia_Result> ConsultarPlatoDia()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarPlatoDia_Result>("ConsultarPlatoDia");
        }
    }
}
