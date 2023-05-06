using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PaginaWeb_LiceoExperimental
{
    public class DatosUsuario
    {
        private UsuariosEntities entity = new UsuariosEntities();

        /**
         * Registrar
         * returns true en caso de exito, false en fracaso
         *
         * Metodo que se encarga de ingresar un nuevo usuario estudiante a la BD y ademas verifica que si se haya creado de forma correcta
         */
        public bool Registrar(string correo, string uname, string pass, string nombre, string apellido1, string apellido2, int genero, string id, int type, string telf)
        {
            using (entity = new UsuariosEntities())
            {
                try
                {

                    entity.Insertar_Usuario(correo, uname, pass, 1, false, false, nombre, apellido1, null, apellido2, null, null, (byte)genero, null, id, (byte)type, telf);

                    if (entity.IdentificadorPersona.Where(a => a.Valor.Equals(id)).ToList().Count() > 0)
                    {
                        return true;
                    }

                    return false;

                }catch(Exception ex)
                {
                    return false;
                }
            }
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
         * Ingresar
         * returns una lista con los datos de entrada de la BD del usuario que acaba de ingresar
         * 
         * Verifica con la base de datos las credenciales de inicio de sesión para hacer dicha accion
         */
        public List<Ingresar_Result> Ingresar(string correo, string pass)
        {
            using (entity = new UsuariosEntities())
            {
                return entity.Ingresar(correo, pass).ToList();

            }
        }
    }
}