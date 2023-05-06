using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Profes
{
    public class DatosProfesores
    {
        private ProfesoresEntities entity = new ProfesoresEntities();

        /**
         * ListarProfesores
         * returns entradas de BD segun los parametros
         * 
         * Metodo que regresa todos los profesores presentes en la base de datos
         */
        public List<ListarProfesores_Result> ListarProfesores()
        {
            using (entity = new ProfesoresEntities())
            {
                return entity.ListarProfesores().ToList();

            }
        }

        /**
         * BuscarProfesor
         * returns entradas de BD segun los parametros
         * 
         * Metodo que regresa todos a los profesores que tengan el id del parametro
         */
        public List<ConsultarProfesor_ID_Result> BuscarProfesor(int n)
        {
            using (entity = new ProfesoresEntities())
            {
                return entity.ConsultarProfesor_ID(n).ToList();

            }
        }

        /**
         * BuscarProfesorNombre
         * returns entradas de BD segun los parametros
         * 
         * Metodo que regresa todos a los profesores que tengan el nombre del parametro
         */
        public List<ConsultarProfesor_Nombre_Result> BuscarProfesorNombre(string n)
        {
            using (entity = new ProfesoresEntities())
            {
                return entity.ConsultarProfesor_Nombre(n).ToList();

            }
        }

        /**
         * EliminarProfesor
         * returns true si fue exitoso, false si fallo
         * 
         * Metodo que elimina un profesor y verifica esto,
         */
        public bool EliminarProfesor(int n)
        {

            try
            {
                using (entity = new ProfesoresEntities())
                {
                    entity.EliminarProfesor(n);

                    List<Profesores> l = entity.Profesores.Where(a => a.ProfesorID == n).ToList();

                    if (l.Count() > 0)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /**
         * InsertarProfesor
         * returns true si fue exitoso, false si fallo
         * 
         * Metodo que inserta un profesor y verifica esto,
         */
        public bool InsertarProfesor(string descripcion, byte[] img, string priNom, string segNom, string priApe, string segApe, string contacto, string telefono)
        {

            try
            {
                using (entity = new ProfesoresEntities())
                {
                    entity.AgregarProfesor(descripcion, img, priNom, segNom, priApe, segApe, contacto, telefono);


                    List<Profesores> l = entity.Profesores.ToList();

                    if (l[l.Count() - 1].Contacto.Equals(contacto) && l[l.Count() - 1].Descripcion.Equals(descripcion))
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

        /**
         * ModificarProfesor
         * returns true si fue exitoso, false si fallo
         * 
         * Metodo que Modificar un profesor y verifica esto,
         */
        public bool ModificarProfesor(int id, string descripcion, byte[] img, string priNom, string segNom, string priApe, string segApe, string contacto, string telefono)
        {
            try
            {
                using (entity = new ProfesoresEntities())
                {
                    entity.ModificarProfesor(id, descripcion, img, priNom, segNom, priApe, segApe, contacto, telefono);

                    List<Profesores> l = entity.Profesores.Where(a => a.ProfesorID == id).ToList();

                    if (l[0].Contacto.Equals(contacto) && l[0].Descripcion.Equals(descripcion))
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

        //************************************************************************************

        /**
         * ListarSecciones
         * returns entradas de BD segun los parametros
         * 
         * Metodo que regresa todos las secciones presentes en la base de datos
         */
        public List<ListarSecciones_Result> ListarSecciones()
        {
            using (entity = new ProfesoresEntities())
            {
                return entity.ListarSecciones().ToList();

            }
        }

        /**
         * ListarSeccionesDesc
         * returns entradas de BD segun los parametros
         * 
         * Metodo que regresa todas las secciones que tengan las siglas del parametro
         */
        public List<ConsultarSeccion_Descripcion_Result> ListarSeccionesDesc(string desc)
        {
            using (entity = new ProfesoresEntities())
            {
                return entity.ConsultarSeccion_Descripcion(desc).ToList();

            }
        }

        /**
         * BuscarSeccion
         * returns entradas de BD segun los parametros
         * 
         * Metodo que regresa todas las secciones que tengan el id del parametro
         */
        public List<ConsultarSeccion_ID_Result> BuscarSeccion(int n)
        {
            using (entity = new ProfesoresEntities())
            {
                return entity.ConsultarSeccion_ID(n).ToList();

            }
        }

        /**
         * EliminarSeccion
         * returns true si fue exitoso, false si fallo
         * 
         * Metodo que elimina una seccion y verifica esto,
         */

        public bool EliminarSeccion(int n)
        {
            try
            {
                using (entity = new ProfesoresEntities())
                {
                    entity.EliminarSeccion(n);

                    List<Seccion> l = entity.Seccion.Where(a => a.SeccionID == n).ToList();

                    if (l.Count() > 0)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /**
         * InsertarSeccion
         * returns true si fue exitoso, false si fallo
         * 
         * Metodo que inserta una seccion y verifica esto,
         */
        public bool InsertarSeccion(string descripcion, int n)
        {
            try
            {
                using (entity = new ProfesoresEntities())
                {
                    entity.AgregarSeccion(descripcion, n);


                    List<Seccion> l = entity.Seccion.ToList();

                    if (l[l.Count() - 1].ProfesorID == n && l[l.Count() - 1].Descripcion.Equals(descripcion))
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

        /**
         * InsertarSeccion
         * returns true si fue exitoso, false si fallo
         * 
         * Metodo que modifica una seccion y verifica esto,
         */
        public bool ModificarSeccion(int id, string descripcion, int n)
        {

            try
            {
                using (entity = new ProfesoresEntities())
                {
                    entity.ModificarSeccion(id, descripcion, n);

                    List<Seccion> l = entity.Seccion.Where(a => a.SeccionID == id).ToList();


                    if (l[0].ProfesorID == n && l[0].Descripcion.Equals(descripcion))
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