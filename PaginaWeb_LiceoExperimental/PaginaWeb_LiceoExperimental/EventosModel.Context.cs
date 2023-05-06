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
    
    public partial class EventosEntities : DbContext
    {
        public EventosEntities()
            : base("name=EventosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<LineaEvento> LineaEvento { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<TipoDireccion> TipoDireccion { get; set; }
        public virtual DbSet<TipoUbicacionGeografica> TipoUbicacionGeografica { get; set; }
        public virtual DbSet<UbicacionGeografica> UbicacionGeografica { get; set; }
    
        public virtual int Agregar_Participantes(string rol, Nullable<long> eventoID)
        {
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            var eventoIDParameter = eventoID.HasValue ?
                new ObjectParameter("EventoID", eventoID) :
                new ObjectParameter("EventoID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Agregar_Participantes", rolParameter, eventoIDParameter);
        }
    
        public virtual ObjectResult<ConsultarEvento_ID_Result> ConsultarEvento_ID(Nullable<long> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarEvento_ID_Result>("ConsultarEvento_ID", iDParameter);
        }
    
        public virtual ObjectResult<ConsultarEvento_PorFecha_Result> ConsultarEvento_PorFecha(Nullable<System.DateTime> fecha)
        {
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarEvento_PorFecha_Result>("ConsultarEvento_PorFecha", fechaParameter);
        }
    
        public virtual ObjectResult<ConsultarEvento_PorNombre_Result> ConsultarEvento_PorNombre(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarEvento_PorNombre_Result>("ConsultarEvento_PorNombre", nombreParameter);
        }
    
        public virtual int Eliminar_Participantes(Nullable<int> participanteID)
        {
            var participanteIDParameter = participanteID.HasValue ?
                new ObjectParameter("ParticipanteID", participanteID) :
                new ObjectParameter("ParticipanteID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Eliminar_Participantes", participanteIDParameter);
        }
    
        public virtual int EliminarEvento(Nullable<long> lineaEventoID)
        {
            var lineaEventoIDParameter = lineaEventoID.HasValue ?
                new ObjectParameter("LineaEventoID", lineaEventoID) :
                new ObjectParameter("LineaEventoID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarEvento", lineaEventoIDParameter);
        }
    
        public virtual ObjectResult<ListarEventos_Result> ListarEventos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarEventos_Result>("ListarEventos");
        }
    
        public virtual ObjectResult<ListarTodosEventos_Result> ListarTodosEventos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarTodosEventos_Result>("ListarTodosEventos");
        }
    
        public virtual int Modificar_Evento(Nullable<long> eventoID, string nombre, string descripcion, Nullable<System.DateTime> fecha, byte[] imagen)
        {
            var eventoIDParameter = eventoID.HasValue ?
                new ObjectParameter("EventoID", eventoID) :
                new ObjectParameter("EventoID", typeof(long));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Modificar_Evento", eventoIDParameter, nombreParameter, descripcionParameter, fechaParameter, imagenParameter);
        }
    
        public virtual int Modificar_Participantes(Nullable<int> participanteID, string rol, Nullable<long> eventoID)
        {
            var participanteIDParameter = participanteID.HasValue ?
                new ObjectParameter("ParticipanteID", participanteID) :
                new ObjectParameter("ParticipanteID", typeof(int));
    
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            var eventoIDParameter = eventoID.HasValue ?
                new ObjectParameter("EventoID", eventoID) :
                new ObjectParameter("EventoID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Modificar_Participantes", participanteIDParameter, rolParameter, eventoIDParameter);
        }
    
        public virtual int Agregar_Evento(string nombre, string descripcion, Nullable<System.DateTime> fecha, byte[] imagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Agregar_Evento", nombreParameter, descripcionParameter, fechaParameter, imagenParameter);
        }
    }
}
