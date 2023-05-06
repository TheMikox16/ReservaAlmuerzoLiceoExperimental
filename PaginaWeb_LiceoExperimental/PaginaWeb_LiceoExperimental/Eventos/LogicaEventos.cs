using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Eventos
{
    public class LogicaEventos
    {
        private DatosEventos datos = new DatosEventos();


        /**
         * ListarEventos
         * returns una lista con los datos resultantes de la base de datos
         * 
         * Es un metodo que llama a la base de datos para listar los eventos actuales y acomoda los resultados para generar la vista
         * de eventos
         */
        public List<Object[]> ListarEventos()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ListarEventos_Result> ls = datos.ListarEventos();//consulta capa datos

            foreach (ListarEventos_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.EventoID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy hh:mm tt");
                temp[4] = "" + p.Descripcion;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BuscarEvento
         * returns una lista con los datos resultantes de la base de datos
         * 
         * Es un metodo que llama a la base de datos para mostrar un evento y acomoda los resultados para generar la vista
         * de eventos o llenar los campos en la pantalla de modificar
         */
        public List<Object[]> BuscarEvento(long id)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarEvento_ID_Result> ls = datos.BuscarEvento(id);//consulta capa datos

            foreach (ConsultarEvento_ID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.EventoID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy hh:mm tt");
                temp[4] = "" + p.Descripcion;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * ListarTodosEventos
         * returns una lista con los datos resultantes de la base de datos
         * 
         * Es un metodo que llama a la base de datos para mostrar todos los eventos y acomoda los resultados para generar la vista
         * de eventos. Usado en administracion
         */
        public List<Object[]> ListarTodosEventos()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ListarTodosEventos_Result> ls = datos.ListarTodosEventos();//consulta capa datos

            foreach (ListarTodosEventos_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.EventoID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy hh:mm tt");
                temp[4] = "" + p.Descripcion;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BuscarEventoTitulo
         * returns una lista con los datos resultantes de la base de datos
         * 
         * Es un metodo que llama a la base de datos para mostrar les eventos segun su titulo y acomoda los resultados para
         * generar la tabla de eventos. Usado en administracion
         */
        public List<Object[]> BuscarEventoTitulo(string titulo)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarEvento_PorNombre_Result> ls = datos.BuscarEventoTitulo(titulo);//consulta capa datos

            foreach (ConsultarEvento_PorNombre_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.EventoID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy hh:mm tt");
                temp[4] = "" + p.Descripcion;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BorrarEvento
         * returns string con mensaje de exito o de fracaso
         * 
         * Este metodo determina si en la capa de datos se ha logrado o no borrar el evento y con ello genera un mensaje
         * para el usuario que es pasado posterioremente a las vistas
         */
        public string BorrarEvento(long id)
        {
            if (datos.BorrarEvento(id))
            {
                return "Evento eliminado de forma éxitosa";
            }
            else
            {
                return "Error al eliminar evento";
            }
        }

        /**
         * ModificarEvento
         * returns string con mensaje de exito o de fracaso
         * 
         * Este metodo determina si en la capa de datos se ha logrado o no modificar el evento y con ello genera un mensaje
         * para el usuario que es pasado posterioremente a las vistas
         */
        public string ModificarEvento(long id, string titulo, string descripcion, byte[] img, DateTime fecha)
        {
            if (datos.ModificarEvento(id, titulo, descripcion, img, fecha))
            {
                return "Evento modificado de forma éxitosa";
            }
            else
            {
                return "Error al modificar evento";
            }
        }

        /**
         * InsertarEvento
         * returns string con mensaje de exito o de fracaso
         * 
         * Este metodo determina si en la capa de datos se ha logrado o no insertar el evento y con ello genera un mensaje
         * para el usuario que es pasado posterioremente a las vistas
         */
        public string InsertarEvento(string titulo, string descripcion, byte[] img, DateTime fecha)
        {
            if(datos.InsertarEvento(titulo, descripcion, img, fecha))
            {
                return "Evento creado de forma éxitosa";
            }
            else
            {
                return "Error al insertar evento";
            }
        }
    }
}
