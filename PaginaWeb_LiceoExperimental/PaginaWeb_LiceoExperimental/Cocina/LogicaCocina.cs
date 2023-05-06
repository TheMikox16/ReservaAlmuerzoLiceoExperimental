using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Cocina
{

    /**
     * Capa de logica del Modulo de Cocina
     * 
     * Se encarga de hacer la conexión y validaciones entre el back-end y la capa de datos
     */

    public class LogicaCocina
    {
        private DatosCocina datos = new DatosCocina();

        /**
         * BuscarPlatillo
         * returns una lista con los datos resultantes de la base de datos
         * 
         * Es un metodo que llama a la base de datos para buscar un platillo y acomoda los resultados para generar la tabla
         * de almuerzos
         * 
         */
        public List<Object[]> BuscarPlatillo(string nombre)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<Platillo> ls = datos.BuscarPlatillo(nombre);

            foreach (Platillo p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PlatilloID;
                temp[1] = p.Fotografia;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Descripcion;
                temp[4] = "" + p.Habilitado;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * ListarPlatillos
         * returns una lista con los datos resultantes de la base de datos
         * 
         * Es un metodo que llama a la base de datos para listar todos los platillos y acomoda los resultados para generar la tabla
         * de almuerzos
         */
        public List<Object[]> ListarPlatillos()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<Platillo> ls = datos.ListarPlatillos();//consulta capa datos

            foreach (Platillo p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PlatilloID;
                temp[1] = p.Fotografia;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Descripcion;
                temp[4] = "" + p.Habilitado;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * ModificarPlatillo
         * returns string con mensaje de error/confirmación
         * 
         * Es un metodo que llama a la base de datos para buscar un platillo y actualizar sus datos
         */
        public string ModificarPlatillo(int id, string nombre, string descripcion, byte[] img, int id_opt)
        {
            bool disponible = false;
            if(id_opt == 0)//Verifica que la opcion elegida de "disponible" fuese Si
            {
                disponible = true;
            }

            if (datos.ModificarPlatillo(id, nombre, descripcion, img, disponible)) 
            {
                return "Datos de platillo modificados con éxito";
            }
            else
            {
                return "Error al modificar platillo";
            }
        }

        /**
         * InsertarPlatillo
         * returns string con mensaje de error/confirmación
         * 
         * Es un metodo que llama a la base de datos para insertar un platillo 
         */
        public string InsertarPlatillo(string nombre, string descripcion, byte[] img, int id_opt) {

            bool disponible = false;
            if (id_opt == 0)//Verifica que la opcion elegida de "disponible" fuese Si
            {
                disponible = true;
            }

            if(datos.InsertarPlatillo(nombre, descripcion, img, disponible))
            {
                return "Creación de platillo exitosa";
            }
            else
            {
                return "Error al modificar platillo";
            }

        }

        /**
         * BuscarPlatilloID
         * returns una lista con los datos resultantes de la base de datos segun ID
         * 
         * Es un metodo que llama a la base de datos para buscar un platillo y acomoda los resultados para generar los detalles
         * de un platillo, se usa para la vista de Detalle.aspx y para las listas de reservas
         * El ID se obtiene a nivel programa de las tablas
         */
        public List<Object[]> BuscarPlatilloID(int id)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<Platillo> ls = datos.BuscarPlatilloID(id);

            foreach (Platillo p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PlatilloID;
                temp[1] = p.Fotografia;
                temp[2] = "" + p.Nombre;
                temp[3] = "" + p.Descripcion;
                temp[4] = "" + p.Habilitado;
                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * EliminarPlatillo
         * return true si el platillo fue eleminado, false caso contrario
         * 
         * Un metodo snecillo que solo llama a la base de datos y el SP de eliminar
         */
        public bool EliminarPlatillo(int id)
        {
            return datos.EliminarPlatillo(id);
        }

        /**
         * VerificarPlatoDia
         * return true si el platillo del dia fue seleccionado, false caso contrario
         * 
         * Un metodo snecillo que solo llama a la base de datos y el SP de verificar plato dia
         */
        public bool VerificarPlatoDia()
        {
            return datos.VerificarPlatoDia();
        }

        /**
         * SelecionaAlmuerzoDia
         * return true si el platillo del dia fue seleccionado, false caso contrario
         * 
         * Un metodo snecillo que solo llama a la base de datos y el SP de seleccionar almuerzo
         */
        public string SeleccionarAlmuerzoDia(int id)
        {
            if (datos.SeleccionarAlmuerzoDia(id))
            {
                return "Platillo del día ha sido seleccionado correctamente";
            }
            else
            {
                return "Error al seleccionar el platillo del día";
            }
        }

        /**
         * VerificarPlatoDia
         * return true si el platillo del dia fue seleccionado, false caso contrario
         * 
         * Un metodo snecillo que solo llama a la base de datos y el SP de verificar plato dia
         */
        public int ConsultarPlatoDia()
        {
            int? n = -1;
            ConsultarPlatoDia_Result plDia;

            List<ConsultarPlatoDia_Result> l = datos.ConsultarPlatoDia();

            if(l.Count() > 0)
            {
                plDia = l[0];
                n = plDia.PlatilloID;
            }

            return Int32.Parse(n+"");
        }

        /**
         * VerificarDisponible
         * return true si el platillo que se quiere seleccionar como platillo del día esta disponible o no
         * 
         * Un metodo snecillo que solo llama a la base de datos y el Query para ver si un platillo esta disponible
         */
        public bool VerificarDisponible(int id)
        {
            return (bool) datos.VerificarDisponible(id);
        }


        //-----------------------------------------------------------------------------------------------------

        /**
         * Reservar
         * return un string con un mensaje que muestra si se ha logrado reservar o no (y en este ultimo dice la causa)
         * 
         * Metodo que primero verifica si el estudiante es becado por medio de VerificarBecado, en caso de que lo sea
         * intenta reservar, si lo logra, entonces la reserva ya esta hecha, sino significa que ya ha habido una reserva
         * de ese usuario, por lo que el proceso se cancela (un almuerzo por persona)
         * 
         * Si el estudiante no es becado, simplemente verifica que la reserva se hizo o no con anterioridad (si el usuario
         * pago para una reserva). En caso positivo, dira que ya se ha reservado, en caso negativo, se le insta a pagar su
         * reserva si quiere un almuerzo
         */
        public string Reservar(long id)
        {


            if (datos.VerificarBecado(id))
            {
                if (datos.Reservar(id))
                {
                    return "¡Se ha reservado el almuerzo con éxito!";
                }
                else
                {
                    return "¡Ya se había reservado un almuerzo! Solo un almuerzo por persona";
                }
            }

            if (!datos.VerificarReserva(id))
            {
                return "¡Ya ha pagado su almuerzo y su reserva esta hecha! Solo un almuerzo por persona";
            }

            return "Usuario no becado, se requiere pago para reserva, por favor pasar a la cajilla correspondiente para pago. Si usted es estudiante becado, por favor, contactarse con el personal para actualizar su condición";


        }

        /**
         * ReservarAdmin
         * return un string con un mensaje que muestra si se ha logrado reservar o no (y en este ultimo dice la causa)
         * 
         * Es muy parecido a Reserva ya que verifica si la reserva ya se ha hecho con anterioridad para un usuario (una reserva
         * por usuario) pero sin tomar en cuenta las condiciones de Beca (es para admins, profesores con permiso y cocineros/as)
         */
        public string ReservarAdmin(long id)
        {
            if (datos.Reservar(id))
            {
                return "¡Se ha reservado el almuerzo con éxito!";
            }

            return "¡Ya se había reservado un almuerzo! Solo un almuerzo por persona";

        }

        /**
         *VerificarHora
         * return bool true que indica si ya es hora de reservar, false caso contrario
         * 
         * Metodo sencillo que llama a VerificarHora de la capa de datos
         */
        public bool VerificarHora()
        {
            return datos.VerificarHora();

        }

        /**
         * ListarReservas
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo hace una consulta de todas las reservas (sin filtros) y ordena las entradas obtenidas para ser desplegadas
         * en forma de tablas en las vistas
         * 
         * El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> ListarReservas()
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];
            long n = 0;

            List<ConsultarPlatoDia_Result> l = datos.ConsultarPlatoDia();

            if (l.Count() > 0)
            {
                n = l[0].PlatilloDiaID;
            }

            List<ListaReserva_Result> ls = datos.ListarReservas(n);

            foreach (ListaReserva_Result p in ls)
            {
                temp = new Object[10];
                
                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;
                temp[3] = "" + p.Fecha;
                temp[4] = p.Estado;

                resultado.Add(temp);
            }

            return resultado;

        }


        /**
         * BuscarReserva
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo hace una consulta de todas las reservas con el filtro de nombre de la persona y ordena las 
         * entradas obtenidas para ser desplegadas en forma de tablas en las vistas
         * 
         * El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> BuscarReserva(string nombre)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            long n = 0;

            List<ConsultarPlatoDia_Result> l = datos.ConsultarPlatoDia();

            if (l.Count() > 0)
            {
                n = l[0].PlatilloDiaID;
            }

            List<ConsultarReservas_PorNombre_Result> ls = datos.BuscarReserva(nombre, n);

            foreach (ConsultarReservas_PorNombre_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;
                temp[3] = "" + p.Fecha;
                temp[4] = p.Estado;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BuscarReservaID
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo hace una consulta de todas las reservas con el filtro de id de la persona y ordena las 
         * entradas obtenidas para ser desplegadas en forma de tablas en las vistas
         * 
         * El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> BuscarReservaID(string id)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            long n = 0;

            List<ConsultarPlatoDia_Result> l = datos.ConsultarPlatoDia();

            if (l.Count() > 0)
            {
                n = l[0].PlatilloDiaID;
            }

            List<ConsultarReservasPorID_Result> ls = datos.BuscarReservaID(id, n);

            foreach (ConsultarReservasPorID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;
                temp[3] = "" + p.Fecha;
                temp[4] = p.Estado;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * ReservasPendientes
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo hace una consulta de todas las reservas que tengan el estado "Entregado = 0" en la BD y ordena las 
         * entradas obtenidas para ser desplegadas en forma de tablas en las vistas
         * 
         * El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> ReservasPendientes()
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            long n = 0;

            List<ConsultarPlatoDia_Result> l = datos.ConsultarPlatoDia();

            if (l.Count() > 0)
            {
                n = l[0].PlatilloDiaID;
            }

            List<ConsultarReservas_PorFecha_Pendientes_Result> ls = datos.ReservasPendientes(n);

            foreach (ConsultarReservas_PorFecha_Pendientes_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;
                temp[3] = "" + p.Fecha;
                temp[4] = p.Estado;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * EntregarPlatillo
         * return true si el almuezo se ha entregado sin problemas, false en caso contrario
         * 
         * Metodo sencillo para cambiar la variable Entrega de la BD de 0 a 1 (se entrega el almuerzo)
         */
        public bool EntregarPlatillo(long id)
        {
            return datos.EntregarPlatillo(id);
        }

        /**
         * ListarNoBecados
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo consulta una lista completa de los estudiantes (rol 1) los cuales no tienen beca (Beca = 0 en BD)
         * y posteriormente los ordena para desplegarse como tablas en las vistas
         * 
         *  El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> ListarNoBecados()
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<ListarNoBecados2_Result> ls = datos.ListarNoBecados();

            foreach (ListarNoBecados2_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BuscarNoBecados
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo consulta una lista completa de los estudiantes (rol 1) los cuales no tienen beca (Beca = 0 en BD)
         * y segun el parametro de busqueda (nombre). Posteriormente los ordena para desplegarlos como tablas en la vista
         * 
         * El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> BuscarNoBecados(string nombre)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<ListarNoBecadosNombre_Result> ls = datos.BuscarNoBecados(nombre);

            foreach (ListarNoBecadosNombre_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;

                resultado.Add(temp);
            }

            return resultado;

        }

        /**
         * BuscarNoBecadosID
         * return Lista de Arrays de Objeto, que contendra el resultado de las entradas de la respectiva consulta
         * 
         * Este metodo consulta una lista completa de los estudiantes (rol 1) los cuales no tienen beca (Beca = 0 en BD)
         * y segun el parametro de busqueda (identificacion). Posteriormente los ordena para desplegarlos como tablas en la vista
         * 
         * El return es tipo array object porque se regresan tanto strings como ints y bytearray
         */
        public List<Object[]> BuscarNoBecadosID(string id)
        {
            List<Object[]> resultado = new List<Object[]>();
            Object[] temp = new Object[5];

            List<ListarNoBecadosID_Result> ls = datos.BuscarNoBecadosID(id);

            foreach (ListarNoBecadosID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.PersonaID;
                temp[1] = p.PrimerNombre + " " + p.PrimerApellido + " " + p.SegundoApellido;
                temp[2] = "" + p.Valor;

                resultado.Add(temp);
            }

            return resultado;

        }

    }
}