using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Profes
{
    public class LogicaProfesores
    {

        private DatosProfesores datos = new DatosProfesores();

        /**
         * ListarProfesores
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Metodo que regresa todos los profesores en la BD y los ordena para su despliegue en tablas. Usado en administración
         * y en la vista de profes.
         */
        public List<Object[]> ListarProfesores()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ListarProfesores_Result> ls = datos.ListarProfesores();


            foreach (ListarProfesores_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.ProfesorID;
                temp[1] = p.Imagen;
                temp[2] = p.Nombre;
                resultado.Add(temp);
            }

            return resultado;
        }

        /**
         * BuscarProfesor
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Metodo que regresa todos los profesores en la BD que coincidan con el parametro de busqueda y los ordena para 
         * su despliegue en tablas. Usado en administración y en la vista de profes.
         * 
         * El id se obtiene de las tablas de las vistas y no es digitado por el usuario. Se utiliza para detalles
         */
        public List<Object[]> BuscarProfesor(int n)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarProfesor_ID_Result> ls = datos.BuscarProfesor(n);


            foreach (ConsultarProfesor_ID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.ProfesorID;
                temp[1] = p.Imagen;
                temp[2] = p.Nombre;
                temp[3] = p.Descripcion;
                temp[4] = p.Contacto;
                temp[5] = p.NumeroTelefono;
                resultado.Add(temp);
            }

            return resultado;
        }

        /**
         * BuscarProfesorNombre
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Metodo que regresa todos los profesores en la BD que coincidan con el parametro de busqueda y los ordena para 
         * su despliegue en tablas. Usado en administración y en la vista de profes.
         */
        public List<Object[]> BuscarProfesorNombre(string n)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarProfesor_Nombre_Result> ls = datos.BuscarProfesorNombre(n);


            foreach (ConsultarProfesor_Nombre_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.ProfesorID;
                temp[1] = p.Imagen;
                temp[2] = p.Nombre;
                temp[3] = p.Descripcion;
                temp[4] = p.Contacto;
                temp[5] = p.NumeroTelefono;
                resultado.Add(temp);
            }

            return resultado;
        }

        /**
         * EliminarProfesor
         * returns mensaje de exito o fracaso
         * 
         * Metodo que borra a un profesor de la base por medio de su ID de BD
         * 
         * El id se obtiene de las tablas de las vistas y no es digitado por el usuario. 
         */
        public string EliminarProfesor(int n)
        {
            if(datos.EliminarProfesor(n))
            {
                return "Profesor eliminado de forma éxitosa";
            }
            else
            {
                return "Error al eliminar profesor";
            }
        }

        /**
         * InsertarProfesor
         * returns mensaje de exito o fracaso
         * 
         * Metodo que inserta un nuevo porfesor segun los parametros y atributos del mismo
         */
        public string InsertarProfesor(string descripcion, byte[] img, string priNom, string segNom, string priApe, string segApe, string contacto, string telefono)
        {
            if(datos.InsertarProfesor(descripcion, img, priNom, segNom, priApe, segApe, contacto, telefono))
            {
                return "Profesor creado de forma éxitosa";
            }
            else
            {
                return "Error al insertar profesor";
            }

        }

        /**
         * EliminarProfesor
         * returns mensaje de exito o fracaso
         * 
         * Metodo que modifica un nuevo porfesor segun los parametros y atributos del mismo y su ID de base de datos
         * 
         * El id se obtiene de las tablas de las vistas y no es digitado por el usuario. 
         */
        public string ModificarProfesor(int id, string descripcion, byte[] img, string priNom, string segNom, string priApe, string segApe, string contacto, string telefono)
        {
            if(datos.ModificarProfesor(id, descripcion, img, priNom, segNom, priApe, segApe, contacto, telefono))
            {
                return "Profesor modificado de forma éxitosa";
            }
            else
            {
                return "Error al modificar profesor";
            }

        }

        /**
         * ConsultarProfesor
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Alternativa a BuscarProfesor pero con mas variables de retorno para la vista de modificacion
         */
        public List<Object[]> ConsultarProfesor(int n)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarProfesor_ID_Result> ls = datos.BuscarProfesor(n);


            foreach (ConsultarProfesor_ID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.ProfesorID;
                temp[1] = p.Imagen;
                temp[2] = p.PrimerNombre;
                temp[3] = p.SegundoNombre;
                temp[4] = p.PrimerApellido;
                temp[5] = p.SegundoApellido;
                temp[6] = p.Descripcion;
                temp[7] = p.Contacto;
                temp[8] = p.NumeroTelefono;
                resultado.Add(temp);
            }

            return resultado;
        }



        //---------------------------------------------------------------------------------------------------------------

        /**
         * ListarSecciones
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Metodo que regresa todos las secciones y sus profesores asignados en la BD y los ordena 
         * para su despliegue en tablas. Usado en administración y en la vista de secciones,
         */
        public List<Object[]> ListarSecciones()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ListarSecciones_Result> ls = datos.ListarSecciones();


            foreach (ListarSecciones_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.SeccionID;
                temp[1] = p.Descripcion;
                temp[2] = p.Imagen;
                temp[3] = p.Nombre;
                resultado.Add(temp);
            }

            return resultado;
        }

        /**
         * ListarSecciones
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Metodo que regresa todos las secciones y sus profesores asignados en la BD segun sus siglas y los ordena 
         * para su despliegue en tablas. Usado en administración y en la vista de secciones,
         */
        public List<Object[]> ListarSeccionesDesc(string desc)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarSeccion_Descripcion_Result> ls = datos.ListarSeccionesDesc(desc);


            foreach (ConsultarSeccion_Descripcion_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.SeccionID;
                temp[1] = p.Descripcion;
                temp[2] = p.Imagen;
                temp[3] = p.Nombre;
                resultado.Add(temp);
            }

            return resultado;
        }

        /**
         * BuscarSeccion
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Metodo que regresa todos las secciones y sus profesores asignados en la BD y los ordena segun su id
         * para su despliegue en tablas. Usado en detalles
         */
        public List<Object[]> BuscarSeccion(int n)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarSeccion_ID_Result> ls = datos.BuscarSeccion(n);


            foreach (ConsultarSeccion_ID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.SeccionID;
                temp[1] = p.Imagen;
                temp[2] = p.Descripcion;
                temp[3] = p.Nombre;
                temp[4] = p.DecripcionProfesor;
                temp[5] = p.Contacto;
                temp[6] = p.NumeroTelefono;
                resultado.Add(temp);
            }

            return resultado;
        }

        /**
         * EliminarSeccion
         * returns mensaje de exito o de error
         * 
         * Metodo que regresa si la seccion fue eliminada o no como forma de un mensaje a desplegar en el front-end
         */
        public string EliminarSeccion(int n)
        {
            if(datos.EliminarSeccion(n))
            {
                return "Sección eliminada de forma éxitosa";
            }
            else
            {
                return "Error al eliminar sección";
            }
        }

        /**
         * InsertarSeccion
         * returns mensaje de exito o de error
         * 
         * Metodo que regresa si la seccion fue insertada o no como forma de un mensaje a desplegar en el front-end
         */
        public string InsertarSeccion(string descripcion, int n)
        {

            if(datos.InsertarSeccion(descripcion, n))
            {
                return "Sección creada de forma éxitosa";
            }
            else
            {
                return "Error al insertar sección";
            }
        }

        /**
         * ModificarSeccion
         * returns mensaje de exito o de error
         * 
         * Metodo que regresa si la seccion fue modificada o no como forma de un mensaje a desplegar en el front-end
         */
        public string ModificarSeccion(int id, string descripcion, int n)
        {
            if (datos.ModificarSeccion(id, descripcion, n))
            {
                return "Sección modificada de forma éxitosa";
            }
            else
            {
                return "Error al modificar sección";
            }
        }

        /**
         * BuscarSeccion
         * returns una lista de objetos array con las entradas de la BD segun los parametros
         * 
         * Una alternativa a BuscarSeccion para con menos atributos. Usado para modificar
         */
        public List<Object[]> ConsultarSeccion(int n)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarSeccion_ID_Result> ls = datos.BuscarSeccion(n);


            foreach (ConsultarSeccion_ID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.SeccionID;
                temp[1] = p.Descripcion;
                temp[2] = p.ProfesorID;
                resultado.Add(temp);
            }

            return resultado;
        }

    }
}