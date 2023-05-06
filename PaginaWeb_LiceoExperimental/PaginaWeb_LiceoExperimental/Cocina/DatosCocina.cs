using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/**
 * Capa de datos del Modulo de Cocina
 * 
 * Se encarga de llamar a todos los metodos relacionados con los almuerzos y las reservas
 */

namespace PaginaWeb_LiceoExperimental.Cocina
{
    public class DatosCocina
    {
        //Variable entity framework usada para conectar a la base de datos
        private CocinaEntities entity = new CocinaEntities();


        //Platillos


        /**
         * BuscarPlatillo
         * returns: Una lista de platillos, resultado de la busqueda
         * 
         * Se encarga de la busqueda de un platillo segun su nombre. Es la opción por default usada por el usuario
         */
        public List<Platillo> BuscarPlatillo(string nombre)
        {
            using (entity = new CocinaEntities()) //conexion a base de datos
            {
                List<Platillo> busqueda = entity.Platillo.Where(a => a.Nombre.Contains(nombre)).ToList();//uso de linq

                return busqueda;

            }

        }

        /**
         * ListarPlatillos
         * return: La lista de todos los platillos disponibles
         * 
         * Este metodo consultara y regresara todos los platillos resgistrados en la base de datos. 
         */
        public List<Platillo> ListarPlatillos()
        {
            using (entity = new CocinaEntities())
            {
                List<Platillo> busqueda = entity.Platillo.OrderBy(a => a.Nombre).ToList();

                return busqueda;

            }

        }

        /**
         * ModificarPlatillo
         * returns true si el proceso se hizo correctamente, false en caso contrario
         * 
         * Un metodo encargado de realizar la actualización de un platillo si el mismo lo requiere
         */
        public bool ModificarPlatillo(int id, string nombre, string descripcion, byte[] img, bool disponible)
        {
            try
            {
                using (entity = new CocinaEntities())
                {
                    entity.Agregar_Modificar_Platillo(id, nombre, descripcion, img, disponible);//Llamada a Stored Procedure de la base de datos

                    if (entity.Platillo.Where(a => a.PlatilloID == id).ToList()[0].Nombre.Equals(nombre))//Verifica si realmente se ha modificado consultando el nombre
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                return true;
            }catch (Exception e)
            {
                return false;
            }
        }

        /**
         * InsertarPlatillo
         * returns true si el proceso se hizo correctamente, false en caso contrario
         * 
         * Es un metodo sencillo para agregar a la base de datos una nueva alternativa de almuerzo
         */
        public bool InsertarPlatillo(string nombre, string descripcion, byte[] img, bool disponible)
        {
            try
            {
                using (entity = new CocinaEntities())
                {
                    entity.Agregar_Modificar_Platillo(-1, nombre, descripcion, img, disponible);

                    List<Platillo> l = entity.Platillo.ToList();

                    //Esto puede dar problemas si muchos usuarios insertan a la vez, eliminar en ultima instancia o cambiar el count()
                    if (l[l.Count() - 1].Nombre.Equals(nombre))//Saca el ultimo elemento insertado y verifica que sea el mismo que acaba de insertarse
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
         * BuscarPlatilloID
         * returns: Una lista de platillos, resultado de la busqueda
         * 
         * Se encarga de la busqueda de un platillo por el ID. Es una variacion a la busqueda por nombre, pero esta solo
         * se utiliza para fines administrativos. El ID no es suministrado por el usuario sino por una consulta previa de 
         * la lista de platillos.
         */
        public List<Platillo> BuscarPlatilloID(int id)
        {
            using (entity = new CocinaEntities())
            {
                List<Platillo> busqueda = entity.Platillo.Where(a => a.PlatilloID == id).ToList();

                return busqueda;

            }

        }

        /**
         * EliminarPlatillo
         * return: true si fue borrado con exito, false si ocurrio un error
         * 
         * Recibe un id identificador de la base de datos y con ello elimina un cierto platillo. 
         * El ID no es suministrado por el usuario sino por una consulta previa de la lista de platillos.
         */
        public bool EliminarPlatillo(int id)
        {
            try { 
                using (entity = new CocinaEntities())
                {
                    entity.EliminarPlatillo(id);
                    List<Platillo> l = BuscarPlatilloID(id);//Verifica si la entrada aun existe

                    if (l.Count() > 0)//Si la entrada existe
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex) 
            { 
                return false; 
            }
        }

        /**
         * VerificarPlatoDia
         * returns: falso si el platillo de dia no se ha seleccionado, true en caso contrario. Esto regula si se prosigue
         * a seleccionar el plato del dia.
         * 
         * Este metodo es el que determina si el plato del dia ya fue designado por medio de una verificación con la base
         * de datos segun la fecha que corresponda, siendo la verificación la del mismo dia si son antes de las 9am y del dia
         * siguiente si ya son pasadas las 4pm
         * 
         * Usado para parte administrativa y gestion
         */
        public bool VerificarPlatoDia()
        {
            using (entity = new CocinaEntities())
            {

                List<VerificarPlatoDia_Result> l = entity.VerificarPlatoDia().ToList();

                if (l.Count() > 0)
                {
                    return false;
                }

                return true;
            }
        }

        /**
         * SeleccionarAlmuerzoDia
         * return: un true para indicarque el paltillo ha sido seleccionado con exito, false caso contrario
         * 
         * Este metodo sigue a VerificaciónPlatoDia, es el que selecciona cual sera el platillo para el almuerzo del dia y al igual 
         * que VerificarPlatoDia, si se ejecuta antes de las 9:00am del el dia llamese x1, seleccionara el almuerzo para x1, si son 
         * pasadas las 4:00pm, seleccionara el almuerzo para el dia siguiente con antelacion, es decir ya no se asigna a x1, sino a 
         * un dia x2.
         * 
         * Usado para parte administrativa y gestion
         */
        public bool SeleccionarAlmuerzoDia(int id)
        {

            try { 
                using (entity = new CocinaEntities())
                {

                    entity.SeleccionarPlatillo(id);

                    return true;
                }
                
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /**
         * ConsultarPlatoDia
         * return Lista con toda la información del plato del dia
         * 
         * A diferencia de VerificarPlatoDia, este metodo se encarga mas que todo de sacar la información de un almuerzo ya
         * seleccionado. Es decir, mientras VerificarPlatoDia chequea si ya se selecciono el plato, SeleccionarPlatoDia lo elige y
         * ConsultarPlatoDia comparte la información de dicho almuerzo.
         * 
         * 
         * Usado para parte administrativa, gestion y uso normal de usuarios comunes.
         */
        public List<ConsultarPlatoDia_Result> ConsultarPlatoDia()
        {
            using (entity = new CocinaEntities())
            {
                List<ConsultarPlatoDia_Result> l = entity.ConsultarPlatoDia().ToList();

                return l;
            }
        }


        //-------------------------------------------------------------------------------------------------------------


        //Reservas

        /**
         * VerificarReserva   (o VerificarReservaExistente)
         * returns falso si ya existe una reserva de una persona, el programa deberia cancelar la creación de una nueva reserva. 
         * Verdadero si no hay reservas de dicha persona para ese dia.
         * 
         * Este metodo lo que hace es verificar si ya una persona, sea becada o no, ha reservado el almuerzo del dia de ese dia en si,
         * con ello es posible decirle al programa que no genere una segunda reserva y limitar dicho comportamiento.
         * 
         * Igualmente, es usado para que los usuarios no becados sepan con seguridad que ya han reservado y es usado por el metodo
         * Reserva para precisamente controlar la generación de una nueva reserva
         * 
         */
        public bool VerificarReserva(long id)
        {
            using (entity = new CocinaEntities())
            {
                List<VerificarReserva_Result> busqueda = entity.VerificarReserva(id).ToList();//consulta

                if (busqueda != null && busqueda.Count() > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }

        }


        /**
         * Reservar
         * returns true si la reserva se pudo realizar existosamente, false si ya existia una reserva para esa persona.
         * 
         * La gran diferencia entre este metodo y VerificarReserva es que mientras que una nos permite generar variables de control,
         * este metodo lo que hace es directamente agregar una reserva a una persona para el platillo del dia. Depende de VerificarReserva
         * para dicho proposito
         */
        public bool Reservar(long id)
        {
            using (entity = new CocinaEntities())
            {
                List<VerificarReserva_Result> busqueda = entity.VerificarReserva(id).ToList();//consulta

                if (busqueda != null && busqueda.Count() > 0)
                {
                    return false;
                }
                else
                {
                    entity.Agregar_Reserva(false, id);

                    return true;
                }


            }

        }


        
        /**
         * VerificarHora
         * return true si se esta dentro del rango de las horas de reserva, false en caso contrario
         * 
         * Verifica que sean antes de las 9:00am y despues de las 4:00pm para pemitir colocar una nueva reserva. En caso
         * contrario, la variable de retorno restringe este comportamiento
         */
        public bool VerificarHora()
        {
            using (entity = new CocinaEntities())
            {
                int? ntemp = entity.PermisoReserva().ToList()[0];

                int n = Int32.Parse(ntemp + "");

                if (n == 1)
                {
                    return true;
                }

                return false;

            }

        }


        /**
         * ListarReservas
         * returns una lista de todas las reservas del dia (no las totales)
         * 
         * Es un metodo sencillo que regresa los datos de cada reserva que se ha realizado para el almuerzo del dia.
         */
        public List<ListaReserva_Result> ListarReservas(long n)
        {
            using (entity = new CocinaEntities())
            {
                List<ListaReserva_Result> busqueda = entity.ListaReserva(n).ToList();//consulta

                return busqueda;

            }

        }

        /**
         * BuscarReserva
         * returns una lista de los resultados de busqueda de reservas por nombre
         * 
         * Este metodo simplemente busca y muestra los datos de una reserva segun el nombre de una persona
         * Es para uso administrativo
         */
        public List<ConsultarReservas_PorNombre_Result> BuscarReserva(string nombre, long n)
        {
            using (entity = new CocinaEntities())
            {
                List<ConsultarReservas_PorNombre_Result> busqueda = entity.ConsultarReservas_PorNombre(nombre, n).ToList();//consulta

                return busqueda;

            }

        }

        /**
         * BuscarReservaID
         * returns una lista de los resultados de busqueda de reservas por identificacion
         * 
         * Este metodo simplemente busca y muestra los datos de una reserva segun el id de una persona
         * Es para uso administrativo
         */
        public List<ConsultarReservasPorID_Result> BuscarReservaID(string id, long n)
        {
            using (entity = new CocinaEntities())
            {
                List<ConsultarReservasPorID_Result> busqueda = entity.ConsultarReservasPorID(id, n).ToList();//consulta

                return busqueda;

            }

        }

        /**
         * ReservaPendientes
         * returns una lista de los resultados de busqueda de reservas cullo almuerzo no se han entregado aun
         * 
         * Este metodo es mas complejo que los dos anteriores, y es que muestra los datos de todas las reservas que no han
         * sido despachadas o entregadas a la persona que reservo. Es decir, que la variable "Entregado" este en "No"
         * Es para uso administrativo
         */
        public List<ConsultarReservas_PorFecha_Pendientes_Result> ReservasPendientes(long n)
        {
            using (entity = new CocinaEntities())
            {
                List<ConsultarReservas_PorFecha_Pendientes_Result> busqueda = entity.ConsultarReservas_PorFecha_Pendientes(n).ToList();//consulta

                return busqueda;

            }

        }

        /**
          * EntregarPlatillo
          * returns true si el platillo fue entregado con exito, false en caso contrario
          * 
          * Entrega o despacha un platillo que ya fue entregado a una persona. El ID sale de los datos de ListarReservas por medio
          * del uso de la tabla en el Front-End
          */
        public bool EntregarPlatillo(long id)
        {
            try
            {
                using (entity = new CocinaEntities())
                {
                    entity.EntregarPlatillo(id);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /**
         * VerificarBecado
         * returns true si el plato esta disponible, false en caso contrario
         * 
         * Metodo sencillo que verifica la variable disponible de unp platillo
         */
        public bool? VerificarDisponible(int id)
        {
            using (entity = new CocinaEntities())
            {
                return (bool) entity.Platillo.Where(a => a.PlatilloID == id).ToList()[0].Habilitado;
            }
        }
        //*********************************************************************************************

        //Validaciones de Beca

        /**
         * VerificarBecado
         * returns true si el estudiante es becado, false en caso contrario
         * 
         * Metodo sencillo que verifica si el estudiante o persona a reservar es becado o no.
         */
        public bool VerificarBecado(long id)
        {
            using (entity = new CocinaEntities())
            {
                int? ntemp = entity.VerificarBecado(id).ToList()[0];

                int n = Int32.Parse(ntemp + "");

                if (n == 1)
                {
                    return true;
                }

                return false;

            }

        }

        /**
         * ListarNoBecados
         * returns lista de estudiantes no becados
         * 
         * Metodo algo complejo ya que busca los estudiantes sin beca y que especificamente no reservaran el platillo del dia aun
         */
        public List<ListarNoBecados2_Result> ListarNoBecados()//Cambiar Reserva
        {
            using (entity = new CocinaEntities())
            {
                List<ListarNoBecados2_Result> busqueda = entity.ListarNoBecados2().ToList();

                return busqueda;

            }

        }

        /**
         * BuscarNoBecados
         * returns una lista de estudiantes no becados resultado de buscar por nombre
         * 
         * Busca en la lista de no becados las persona/s con el nombre indicado
         * Uso Administrativo.
         */
        public List<ListarNoBecadosNombre_Result> BuscarNoBecados(string nombre)
        {
            using (entity = new CocinaEntities())
            {
                List<ListarNoBecadosNombre_Result> busqueda = entity.ListarNoBecadosNombre(nombre).ToList();

                return busqueda;

            }

        }

        /**
         * BuscarNoBecadosID
         * returns una lista de estudiantes no becados resultado de buscar por identificacion
         * 
         * Busca en la lista de no becados las persona con el id indicado
         * Uso Administrativo.
         */
        public List<ListarNoBecadosID_Result> BuscarNoBecadosID(string id)
        {
            using (entity = new CocinaEntities())
            {
                List<ListarNoBecadosID_Result> busqueda = entity.ListarNoBecadosID(id).ToList();

                return busqueda;

            }

        }

    }
}