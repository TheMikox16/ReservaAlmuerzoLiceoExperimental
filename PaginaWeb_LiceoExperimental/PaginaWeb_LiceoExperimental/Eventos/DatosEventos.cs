using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Eventos
{
    public class DatosEventos
    {
        private EventosEntities entity = new EventosEntities();

        /**
         * ListarEventos
         * returns: una lista de las entradas de la consulta hecha 
         * 
         * Consulta en la BD (con EF) la lista de los eventos que aun no han ocurrido. Uso de tabla para vistas
         */
        public List<ListarEventos_Result> ListarEventos()
        {
            using (entity = new EventosEntities())
            {
                List<ListarEventos_Result> busqueda = entity.ListarEventos().ToList();

                return busqueda;

            }

        }

        /**
         * BuscarEventos
         * returns: una lista de las entradas de la consulta hecha 
         * 
         * Consulta en la BD (con EF) el evento según el id. Usado para modificar y para ver los detalles del evento
         * Recibe un id identificador de la base de datos y con ello consulta. 
         * El ID no es suministrado por el usuario sino por una consulta previa de la lista de eventos.
         */
        public List<ConsultarEvento_ID_Result> BuscarEvento(long id)
        {
            using (entity = new EventosEntities())
            {
                List<ConsultarEvento_ID_Result> busqueda = entity.ConsultarEvento_ID(id).ToList();

                return busqueda;

            }

        }

        /**
         * ListarTodosEventos
         * returns: una lista de las entradas de la consulta hecha 
         * 
         * Consulta en la BD (con EF) la lista de todos los eventos, incluso los ya ocurridos. Uso de tabla para vistas
         */
        public List<ListarTodosEventos_Result> ListarTodosEventos()
        {
            using (entity = new EventosEntities())
            {
                List<ListarTodosEventos_Result> busqueda = entity.ListarTodosEventos().ToList();

                return busqueda;

            }

        }

        /**
         * BuscarEventoTitulo
         * returns: una lista de las entradas de la consulta hecha 
         * 
         * Consulta en la BD (con EF) el evento según el titulo del mismo. Uso de tabla para vistas
         */
        public List<ConsultarEvento_PorNombre_Result> BuscarEventoTitulo(string titulo)
        {
            using (entity = new EventosEntities())
            {
                List<ConsultarEvento_PorNombre_Result> busqueda = entity.ConsultarEvento_PorNombre(titulo).ToList();

                return busqueda;

            }

        }

        /**
         * BorrarEventos
         * returns: true si se ha logado borrar, false en caso contrario
         * 
         * Borra un evento por medio de su id, luego chequea si dicho evento aun se encuentra en la base
         * Recibe un id identificador de la base de datos y con ello elimina. 
         * El ID no es suministrado por el usuario sino por una consulta previa de la lista de eventos.
         */
        public bool BorrarEvento(long id)
        {
            try
            {
                using (entity = new EventosEntities())
                {
                    entity.EliminarEvento(id);

                    List<Evento> l = entity.Evento.Where(a => a.EventoID == id).ToList();//Ver si entrada persiste

                    if (l.Count() > 0)//Si la entrada aun existe
                    {
                        return false;
                    }

                    return true;//Borrado exitoso
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /**
         * ModificarEventos
         * returns: true si se ha logado modificar, false en caso contrario
         * 
         * Modifica un evento por medio de su id, luego chequea si dicho evento aun se encuentra realmente fue moidifcado
         * dicho id es un identificador de la base de datos y con ello modifica. 
         * El ID no es suministrado por el usuario sino por una consulta previa de la lista de eventos.
         */
        public bool ModificarEvento(long id, string titulo, string descripcion, byte[] img, DateTime fecha)
        {
            try { 
                using (entity = new EventosEntities())
                {
                    entity.Modificar_Evento(id, titulo, descripcion, fecha, img);

                    List<Evento> l = entity.Evento.Where(a => a.EventoID == id).ToList();//Obtener evento por id

                    if (l[0].Nombre.Equals(titulo) && l[0].Descripcion.Equals(descripcion))//Si el evento con el id tiene el mismo nombre y descripcion
                    {
                        return true;//Modificación exitosa
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /**
         * InsertarEventos
         * returns: true si se ha logado insertar, false en caso contrario
         * 
         * Inserta un evento por medio de los parametros, luego chequea si dicho evento realmente se inserto
         */
        public bool InsertarEvento(string titulo, string descripcion, byte[] img, DateTime fecha)
        {
            try
            {
                using (entity = new EventosEntities())
                {
                    entity.Agregar_Evento(titulo, descripcion, fecha, img);


                    List<Evento> l = entity.Evento.ToList();//Lista de todos los eventos

                    //Esto podria no funcionar cuando hay varios usuarios haciendo la misma operación a la vez
                    if (l[l.Count() - 1].Nombre.Equals(titulo) && l[l.Count() - 1].Descripcion.Equals(descripcion))//Chequear inserción de ultima entrada con nombre y descripcion para ver si es la misma
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}