using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PaginaWeb_LiceoExperimental.Eventos
{
    public partial class AdministrarEventos : System.Web.UI.Page
    {
        private LogicaEventos logica = new LogicaEventos();
        private string v = "0";

        protected void Page_Load(object sender, EventArgs e)
        {

            //Condicion de control de Sesión expirada. Si el usuario intenta entrar a esta pagina por URL sin haber iniciado sesion
            //o lleva mucho tiempo inactivo se le redirige a el inicio de sesion
            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");// Se le redirige a el inicio de sesion
            }

            int n = int.Parse(Session["rol"] + "");

            if (n == 1 || n == 3)//Si el usuario no es profesor o admin, no deberia estar aqui
            {
                Response.Redirect("../Login.aspx");// Se le redirige a el inicio de sesion
            }

            if (n == 2)//si el usuario es un profesor
            {
                if (!bool.Parse(Session["permiso"] + ""))//Si el usuario es un profeosr pero no tiene un permiso, no deberia estar aqui
                {
                    Response.Redirect("../Login.aspx");// Se le redirige a el inicio de sesion
                }
            }

            v = Request.QueryString["ver"];// Variable de comportamiento que determina si hay que modificar o eliminar



            if (v != null && v.Equals("1"))//Si es 1, se modifica
            {
                Session["EId"] = Request.QueryString["EId"];//Guardamos el ID de la BD para usarlo en formularios posteriores

                Session["ver"] = 0; //reinicio de la variable ver (evitar comportamiento inadecuado al volver a cargar esta pagina)

                Session["insertar"] = 0;//Esto le indica a FormularioEventos que se debe entrar en modo modificar

                Response.Redirect("FormularioEvento.aspx");
            }
            else if (v != null && v.Equals("2"))//Si es 2, se elimina
            {
                Session["EId"] = Request.QueryString["EId"];
                Session["ver"] = 0;
                Session["insertar"] = 0;

                string s = logica.BorrarEvento(long.Parse(Request.QueryString["EId"] + ""));//Llamada a logica para borrar evento

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);//Mensaje de error/confirmación
            }

            if (!this.IsPostBack)//Si es la primera vez que se carga la pagina
            {
                cancelar_btn.Visible = false;//Se oculta el boton de cancelar

                //Con esto evitamos que el boton de cancelar/buscar se muestren a la vez
            }

        }


        /**
         * DataGridCreation
         * return un string en formato HTML que es integrado y desplegado, en general suele contener una tabla aunque en este
         *        caso es mas como una simple vista dinamica
         *        
         * Este metodo es usado ampliamente en el programa. Es el encargado de sacar de las bases de datos las diferentes
         * entradas de cada categoria (en este caso es eventos)
         * 
         * No solo se detiene ahi ya que puede filtrar la cantidad de entradas que optiene por medio de las variables de sesión.
         * 
         * El funcionamiento de este metodo es sencillo: 
         *  1-Primeramente, como se busca crear una tabla, usamos DataTable como una guia para crear una nueva tabla (no va a ser 
         *  el resultado final) y colocamos las columnas que queramos desplegar. En este caso, la columna "Eliminar" y "Modificar" 
         *  son botones, "Imagen" sera una imagen por medio de bytearray y "Titulo" y "Fecha" simples strings.
         *  2-Optenemos una lista de las entradas, segun la condicion que aplique (listar todas o filtrar por busqueda)
         *  3-Añadir cada valor obtenido a la DataTable, menos los botones que de momento quedan en blanco. El orden en el que
         *    colocamos las columnas importan
         *    3.1-En este paso podemos cambiar ciertos valores a nuestro favor, como lo son las imagenes, antes de cargarlo a la tabla
         *  4-Creamos un StringBuilder con el que si se creara el resultado final. La idea es ir nevegando entra las columnas y filas
         *    de la DataTable con toda la información, de tal manera que con el StringBuilder decidimos que va en cada columna
         *    4.1-Creamos condiciones para las columnas que sean botones y creamos un boton httml en vez de una entrada por la que 
         *        hacemos a una llamada a QueryString para control de ciertos comportamientos del programa. Por ejemplo, si queremos
         *        ver o eliminar, tenemos que manejar valores diferentes para cada boton, aunque la variable de session puede llamarse
         *        igual
         *    4.2-La idea de este paso es ser creativo, si necesitamos que un dato se despliegue de una manera o se necesita una 
         *        validación de antemano, esto es posible a lo largo de este paso por medio de las validaciones
         *  5- una vez tengamos el StringBuilder completo, lo regresamos al front-end donde se renderizara la tabla
         *  
         *  El DataGridCreation siempre se genera al cargar la pagina gracias a una llamada del front-end al metodo especificamente.
         */
        public string DataGridCreation()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();

            DataTable table = new DataTable();
            table.Columns.Add("Imagen", typeof(Object));
            table.Columns.Add("Título", typeof(string));
            table.Columns.Add("Fecha", typeof(string));
            table.Columns.Add("Eliminar", typeof(string));//Boton
            table.Columns.Add("Modificar", typeof(string));//Boton



            List<Object[]> list;

            if (Session["opt"] != null && Session["opt"].ToString().Equals("1"))//Si se presiono el boton de busqueda
            {
                list = logica.BuscarEventoTitulo(buscar_txt.Value);//Busqueda
            }
            else
            {
                list = logica.ListarTodosEventos();//Mostrar todo
            }

            //Validacion de imagen
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            foreach (Object[] temp in list)
            {
                if (temp[1] != null)//Si la imagen no es nula
                {
                    //Se renderiza la imagen
                    var r = Convert.ToBase64String((byte[])temp[1]);
                    string s1 = String.Format("data:image;base64,{0}", r);
                    table.Rows.Add(s1, temp[2], temp[3]);

                }
                else
                {
                    //No se renderiza la imagen
                    table.Rows.Add(temp[1], temp[2], temp[3]);
                }
            }

            //strHTMLBuilder.Append("<table id=\"dtBasicExample\" class=\"table table - striped table - bordered\" cellspacing=\"0\" width=\"80%\">");

            //Creación de columnas
            strHTMLBuilder.Append("<thead><tr >");
            foreach (DataColumn myColumn in table.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }

            strHTMLBuilder.Append("</tr></thead><tbody>");


            //variables temporales y de uso concurrido, no siempre se usan (A excepcion de i)S

            bool s; //En caso de que se tenga una variable con un combobox

            byte[] f = null; //temp de imagenes, ignorar


            int i = -1; //indice de recorrido

            long temp2 = -1;//String para guardar el ID identificador de la base de datos y colocarselo a los botones
            //Gracias a esta variable es más facil ubicar las entradas en la BD

            foreach (DataRow myRow in table.Rows)
            {
                f = null;

                i++;//Se sube la posicion actual, como si fuese un for

                temp2 = -1;//Reinicio para no volver a usar el mismo ID sin querer

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in table.Columns)
                {

                    if (myColumn.ColumnName.Equals("Modificar"))//Campo de boton modificar
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (long)list[i][0];//Se obtiene el ID (en este caso EventoID) de la BD (no desde)
                        strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?EId=" + temp2 + "&ver=1\">Modificar</a>");//Se crea un boton donde EId es el identificaro del ID de la BD y ver ka accuón que debe realizase (comportamiento)

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Eliminar"))//Capo de boton eliminar
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (long)list[i][0];
                        strHTMLBuilder.Append("<a ID=\"el\" type=\"button\" runat=\"server\" class=\"btn btn-danger\" href=\"?EId=" + temp2 + "&ver=2\" onclick=\"return confirm('¿Realmente desea borrar este evento?')\">Eliminar</a>");//Se crea un boton donde EId es el identificaro del ID de la BD y ver ka accuón que debe realizase(comportamiento)

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Imagen") && myRow[myColumn.ColumnName].ToString().Length > 0)//Campo imagen
                    {

                        strHTMLBuilder.Append("<td style='width:100px; height:100px;'><img src='");//Se cambia la disposición de la img (tamaño, alto, ancho...)
                        strHTMLBuilder.Append((string)myRow[myColumn.ColumnName]);
                        strHTMLBuilder.Append("' style='max-height:100%; max-width:100%'/></td>");

                        //Imagen.ImageUrl = (string)myRow[myColumn.ColumnName];

                    }
                    else //Si el campo a asignar no es un boton o imagen, se ejecuta esta condicion
                    {
                        strHTMLBuilder.Append("<td >");
                        strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                        strHTMLBuilder.Append("</td>");
                    }



                }
                strHTMLBuilder.Append("</tr>");

            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);//Limpiar cache

            return strHTMLBuilder.ToString();//Retorno de string HTML

        }

        /**
         * Buscar_Click
         * 
         * Metodo de acción al pulsar el boton Buscar. Define la variable de comportamiente de sesión (opt) en buscar (opt = 1).
         * Hace visible el boton cancelar e invisible buscar para poder cambiar a modo estandar al pulsar cancelar 
         */
        protected void Buscar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "1";//Modo de busqueda
            cancelar_btn.Visible = true;
            buscar_btn.Visible = false;
        }


        /**
         * Cancelar_Click
         * 
         * Metodo de acción al pulsar el boton Cancelar. Define la variable de comportamiente de sesión (opt) en buscar (opt = 0).
         * Hace visible el boton buscar e invisible cancelar para poder cambiar a modo busqueda al pulsar buscar
         */
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";//Modo estandar
            cancelar_btn.Visible = false;
            buscar_btn.Visible = true;
        }

        /**
         * Crear_Click
         * 
         * Es el metodo que nos reenvia al formulario para insertar, que es el mismo que el de modificar pero este cambia
         * su comportamiento dinamicamente dependiendo de la variable de session "insertar", la cual se inicializa aqui
         * (insertar = 1, el formulario sera de creación, insertar = 0, el formulario sera de modificación/actualizacion)
         */
        protected void Crear_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";//Reinicio de variable
            Session["insertar"] = "1";//Se le dice a la variable de formulario que entramos a modo Insertar
            cancelar_btn.Visible = false;
            buscar_btn.Visible = true;
            Response.Redirect("FormularioEvento.aspx");

        }

        //Simple mentodo para regresar a la pantalla anterior
        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";//Reinicio de variable
            Response.Redirect("Eventos.aspx");
        }
    }
}