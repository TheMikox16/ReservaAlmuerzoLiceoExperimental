using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Usuarios
{
    public class DatosAdminUsuarios
    {

        private UsuariosEntities entity = new UsuariosEntities();

        /**
         * ListarEstudiantes
         * returns una lista de usuarios estudiantes segun los parametros
         * 
         * Es un metodo que obtiene todas las entradas de los usuarios que son solo estudiantes en la BD
         */
        public List<ListarEstudiantes_Result> ListarEstudiantes()
        {
            using (entity = new UsuariosEntities())
            {
                List<ListarEstudiantes_Result> busqueda = entity.ListarEstudiantes().ToList();

                return busqueda;

            }

        }

        /**
         * BuscarEstudiante
         * returns una lista de usuarios estudiantes segun los parametros
         * 
         * Es un metodo que obtiene todas las entradas de los usuarios que son solo estudiantes y coiniciden con el nombre 
         * del parametro en la BD
         */
        public List<BuscarEstudiante_Result> BuscarEstudiante(string nombre)
        {
            using (entity = new UsuariosEntities())
            {
                List<BuscarEstudiante_Result> busqueda = entity.BuscarEstudiante(nombre).ToList();

                return busqueda;

            }

        }

        /**
         * ActualizarBeca
         * returns una lista de usuarios estudiantes segun los parametros
         * 
         * Es un metodo que por medio del ID de la BD actualiza el camo Beca de un usuario para cambiar su condicion a SI o NO en
         * cualquier momento y segun corresponda (de si a no, de no a si)
         */
        public void ActualizarBeca(long id)
        {
            using (entity = new UsuariosEntities())
            {
                entity.ActualizarBeca(id);
            }
        }

        /**
         * ListarUsuarios
         * returns una lista de usuarios estudiantes segun los parametros
         * 
         * Es un metodo que obtiene todas las entradas de los usuarios sin importar su rol
         */
        public List<ListarUsuarios_Result> ListarUsuarios()
        {
            using (entity = new UsuariosEntities())
            {
                List<ListarUsuarios_Result> busqueda = entity.ListarUsuarios().ToList();

                return busqueda;

            }

        }

        /**
         * BuscarUsurios
         * returns una lista de usuarios estudiantes segun los parametros
         * 
         * Es un metodo que obtiene todas las entradas de los usuarios sin importar su rol y coiniciden con el correo
         * del parametro en la BD
         */
        public List<ConsultarUsuario_Result> BuscarUsuario(string c)
        {
            using (entity = new UsuariosEntities())
            {
                List<ConsultarUsuario_Result> busqueda = entity.ConsultarUsuario(c).ToList();

                return busqueda;

            }

        }


        /**
         * EliminarUsuario
         * returns true en exito, false en fallo
         * 
         * Es un metodo que se encarga de eliminar a un usuario y verificar esto ultimo
         */
        public bool EliminarUsuario(long n)
        {
            try
            {
                using (entity = new UsuariosEntities())
                {
                    entity.EliminarUsuario(n);

                    List<Usuario> l = entity.Usuario.Where(a => a.UsuarioID == n).ToList();

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
         * InsertarUsuario
         * returns true en exito, false en fallo
         * 
         * Es un metodo que se encarga de insertar a un usuario y verificar esto ultimo
         */
        public bool InsertarUsuario(string correo, string uname, string pass, byte rol, bool beca, bool permiso, string nombre, string apellido1, string apellido2, int genero, string id, int type, string telf)
        {
            /**try
            {*/
                using (entity = new UsuariosEntities())
                {
                    entity.Insertar_Usuario(correo, uname, pass, rol, beca, permiso, nombre, apellido1, null, apellido2, null, null, (byte)genero, null, id, (byte)type, telf);

                    List<Usuario> l = entity.Usuario.ToList();

                    if (entity.IdentificadorPersona.Where(a => a.Valor.Equals(id)).ToList().Count() > 0)
                    {

                        if (l[l.Count() - 1].CorreoElectronico.Equals(correo)){
                            return true;
                        }

                        return false;
                    }

                    return false;
                }
            /**}
            catch (Exception e)
            {
                return false;
            }*/
        }

        /**
         * VerificarCorreo
         * returns list de usuarios segun busqueda
         * 
         * Regresa una lista de usuarios con un determinado correo, si esto es verdadero entonecs no puede registrarse al nuevo
         * usuario con el nuevo correo
         */
        public List<Usuario> VerificarCorreo(string correo)
        {
            using (entity = new UsuariosEntities())
            {
                return entity.Usuario.Where(a => a.CorreoElectronico.Equals(correo)).ToList();

            }
        }

        /**
         * ConsultarUsuario
         * returns una lista de usuarios estudiantes segun los parametros
         * 
         * Es un metodo que obtiene todas las entradas de los usuarios sin importar su rol y coiniciden con el id de BD
         * del parametro en la BD
         */
        public List<ConsultarUsuario_ID_Result> ConsultarUsuario(long n)
        {
            using (entity = new UsuariosEntities())
            {
                List<ConsultarUsuario_ID_Result> busqueda = entity.ConsultarUsuario_ID(n).ToList();

                return busqueda;

            }

        }


        /**
         * ModificarUsuario
         * returns true en exito, false en fallo
         * 
         * Es un metodo que se encarga de modificar a un usuario y verificar esto ultimo
         */
        public bool ModificarUsuario(long uid, string correo, string uname, string pass, byte rol, bool beca, bool permiso, string nombre, string apellido1, string apellido2, int genero, string id, int type, string telf)
        {
            using (entity = new UsuariosEntities())
            {
                entity.ModificarUsuario(uid, correo, uname, pass, rol, beca, permiso, nombre, apellido1, apellido2, null, null, null, (byte)genero, null, id, (byte)type, telf);

                List<Usuario> l = entity.Usuario.Where(a => a.UsuarioID == uid).ToList();

                if (entity.IdentificadorPersona.Where(a => a.Valor.Equals(id)).ToList().Count() > 0)
                {
                    if (l[0].CorreoElectronico.Equals(correo))
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
        }
    }
}