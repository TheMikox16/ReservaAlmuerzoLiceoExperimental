using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Usuarios
{
    public class LogicaAdminUsuarios
    {

        private DatosAdminUsuarios datos = new DatosAdminUsuarios();

        /**
         * BuscarEstudiante
         * returns lista de entradas de BD segun el parametro de busqueda
         * 
         * Metodo que se encarga de buscar usuarios estuidantes que conicidan con el parametro del nombres. Luego esta
         * entrada es organizada para proyectarla en las vistas
         */
        public List<Object[]> BuscarEstudiante(string nombre)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<BuscarEstudiante_Result> ls = datos.BuscarEstudiante(nombre);

            foreach (BuscarEstudiante_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.UsuarioID;
                temp[1] = p.Nombre;
                temp[2] = "" + p.Valor;
                temp[3] = p.Becado;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * ListarEstudiantes
         * returns lista de entradas de BD segun el parametro de busqueda
         * 
         * Metodo que se encarga listar todos los usuarios unicamente estudiantes. Luego esta
         * entrada es organizada para proyectarla en las vistas
         */
        public List<Object[]> ListarEstudiantes()
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<ListarEstudiantes_Result> ls = datos.ListarEstudiantes();

            foreach (ListarEstudiantes_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.UsuarioID;
                temp[1] = p.Nombre;
                temp[2] = "" + p.Valor;
                temp[3] = p.Becado;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * ActualizarBeca
         * 
         * Metodo que se encarga de la llamada para actualizar la beca en la BD
         */
        public void ActualizarBeca(long id)
        {
            datos.ActualizarBeca(id);
        }

        /**
         * ListarUsuarios
         * returns lista de entradas de BD segun el parametro de busqueda
         * 
         * Metodo que se encarga de listar todos los usuarios. Luego esta
         * entrada es organizada para proyectarla en las vistas
         */
        public List<Object[]> ListarUsuarios()
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[6];

            List<ListarUsuarios_Result> ls = datos.ListarUsuarios();

            foreach (ListarUsuarios_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.UsuarioID;
                temp[1] = p.Nombre;
                temp[2] = "" + p.Valor;
                temp[3] = p.CorreoElectronico;
                temp[4] = p.Rol;
                temp[5] = p.Permisos;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BuscarUsuario
         * returns lista de entradas de BD segun el parametro de busqueda
         * 
         * Metodo que se encarga de buscar usuarios que conicidan con el parametro del correo. Luego esta
         * entrada es organizada para proyectarla en las vistas
         */
        public List<Object[]> BuscarUsuario(string c)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[6];

            List<ConsultarUsuario_Result> ls = datos.BuscarUsuario(c);

            foreach (ConsultarUsuario_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.UsuarioID;
                temp[1] = p.Nombre;
                temp[2] = "" + p.Valor;
                temp[3] = p.CorreoElectronico;
                temp[4] = p.Rol;
                temp[5] = p.Permisos;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * EliminarUsuario
         * returns string con mesnaje de exito o fracaso
         * 
         * Determina si la eliminación de usuario fue llevada correctamente y da un mensaje para las vistas
         */
        public string EliminarUsuario(long n)
        {
            if(datos.EliminarUsuario(n))
            {
                return "Usuario eliminado de forma éxitosa";
            }
            else
            {
                return "Error al eliminar usuario";
            }
        }

        /**
        * InsertarUsuario
        * returns string con mesnaje de exito o fracaso
        * 
        * Determina si la inserción de usuario fue llevada correctamente y da un mensaje para las vistas
        */
        public string InsertarUsuario(string correo, string uname, string pass, string confirm, byte rol, bool beca, bool permiso, string nombre,  string apellido1, string apellido2, int genero, string id, int type, string telf)
        {
            if (!pass.Equals(confirm))
            {
                return "La contraseñas no coinciden, inténtelo de nuevo";
            }

            if (datos.VerificarCorreo(correo).Count() > 0)
            {
                return "Ese correo ya esta registrado, inténtelo de nuevo";
            }

            if (datos.InsertarUsuario(correo, uname, pass, rol, beca, permiso, nombre, apellido1, apellido2, genero, id, type, telf))
            {
                return "Usuario ingresado con éxito";
            }

            return "Fallo al Registrar";

        }

        /**
         * BuscarUsuario
         * returns lista de entradas de BD segun el parametro de busqueda
         * 
         * Metodo que se encarga de buscar usuarios que conicidan con el parametro del id de BD. Luego esta
         * entrada es organizada para proyectarla en las vistas
         */
        public List<Object[]> ConsultarUsuario(long n)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[14];

            List<ConsultarUsuario_ID_Result> ls = datos.ConsultarUsuario(n);

            foreach (ConsultarUsuario_ID_Result p in ls)
            {
                temp = new Object[14];

                temp[0] = p.UsuarioID;
                temp[1] = p.CorreoElectronico;
                temp[2] = p.NombreUsuario;
                temp[3] = p.PrimerNombre;
                temp[4] = p.PrimerApellido;
                temp[5] = p.SegundoApellido;
                temp[6] = p.Contrasenna;
                temp[7] = ""+p.Rol;
                temp[8] = ""+p.Becado;
                temp[9] = ""+p.Permisos;
                temp[10] = ""+p.GeneroID;
                temp[11] = p.ValorID;
                temp[12] = ""+p.TipoIdentificadorPersonaID;
                temp[13] = p.ValorContacto;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
        * ModificarUsuario
        * returns string con mensaje de exito o fracaso
        * 
        * Determina si la modificacion de usuario fue llevada correctamente y da un mensaje para las vistas
        */
        public string ModificarUsuario(long uid, string correo, string uname, string pass, string confirm, byte rol, bool beca, bool permiso, string nombre, string apellido1, string apellido2, int genero, string id, int type, string telf)
        {
            if (!pass.Equals(confirm))
            {
                return "La contraseñas no coinciden, inténtelo de nuevo";
            }

            if (datos.ModificarUsuario(uid, correo, uname, pass, rol, beca, permiso, nombre, apellido1, apellido2, genero, id, type, telf))
            {
                return "Usuario modificado con éxito";
            }

            return "Fallo al Modfiicar";

        }
    }
}