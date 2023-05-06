using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental
{
    public class LogicaUsuario
    {
        private DatosUsuario datos = new DatosUsuario();

        /**
         * Registro
         * retuns mensaje de exito o de error
         * 
         * Metodo encargado del registro de un nuevo estuidante a la BD, hace todas las validaciones necesarias como verificar
         * el correo para luego hacer la insercción de dicho usuario nuevo.
         */
        public string Registrar(string correo, string uname, string pass, string confirm, string nombre, string apellido1, string apellido2, int genero, string id, int type, string telf)
        {
            if (!pass.Equals(confirm))
            {
                return "La contraseñas no coinciden, intentelo de nuevo";
            }

            if(datos.VerificarCorreo(correo).Count() > 0)
            {
                return "Ese correo ya esta registrado, intentelo de nuevo";
            }

            if (datos.Registrar(correo, uname, pass, nombre, apellido1, apellido2, genero+1, id, type+1, telf))
            {
                return "Usuario registrado con éxito";
            }

            return "Fallo al Registrar";

        }

        /**
         * Ingresar
         * retuns mensaje de exito o de error
         * 
         * Metodo encargado del ingreso al sistema por medio de validación de credenciales en la BD.
         */
        public string[] Ingresar(string correo, string pass)
        {

            List<Ingresar_Result> l = datos.Ingresar(correo, pass);

            string[] s = new string[4];

            s[0] = "El usuario no fue encontrado. Inicio de sesión fallido";

            if (l.Count() > 0)
            {
                s[0] = l[0].PersonaID+"";
                s[1] = l[0].Rol + "";
                s[2] = l[0].NombreUsuario;
                s[3] = l[0].Permisos+"";

                return s;
            }

            return s;
        }

    }
}