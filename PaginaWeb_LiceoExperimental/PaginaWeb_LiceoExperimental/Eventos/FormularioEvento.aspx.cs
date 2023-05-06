using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Eventos
{
    public partial class FormularioEvento : System.Web.UI.Page
    {
        private LogicaEventos logica = new LogicaEventos();
        private int opcion = -1;
        private Object[] temp;


        /*
         * Esta pagina se encarga de recopilar los datos de entrada para modificar o crear entradas a la base de datos.
         * El formulario varia segun el objeto a crear (evento, profesor, sección, platillo...) pero en general
         * la sintaxis es parecida a lo largo del programa
         * 
         * Hay que estan muy pendiente de las validaciones que se le hacen a las imagenes, numeros y strings
         */

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))//Si la sesion esta iniciado o caduco
            {
                Response.Redirect("../Login.aspx");//Regresar a login
            }

            int n = int.Parse(Session["rol"] + "");

            if (n == 1 || n == 3)//Si eres estudiante o de cocina
            {
                Response.Redirect("../Login.aspx");
            }

            if (n == 2)//Si eres profesr
            {
                if (!bool.Parse(Session["permiso"] + ""))//No tienes permiso
                {
                    Response.Redirect("../Login.aspx");
                }
            }

            if (!this.IsPostBack)//Si es primera vez en cargar la pagina
            {
                //Validación del tiempo

                DateTime t = DateTime.Now;//tiempo actual

                string month;

                //Se optiene el formato del mes
                if(t.Month < 10)
                {
                    month = "0" + t.Month;
                }
                else
                {
                    month = "" + t.Month;
                }

                fecha_txt.Attributes.Add("min", "" + t.Year + "-" + month + "-" + t.Day);//Se agrega el valor minimo para el campo de la fecha

                fecha_txt.Value = t.Year + "-" + month + "-" + t.Day;//asignacion de Valor del campo fecha para que no sea nulo
                if((t.Hour + 2) < 10)
                {
                    hora_txt.Value = "0" + (t.Hour + 2) + ":" + t.Minute;//asignacion de Valor del campo hora para que no sea nulo
                }
                else
                {
                    hora_txt.Value = (t.Hour + 2) + ":" + t.Minute;//asignacion de Valor del campo hora para que no sea nulo
                }
                
            }

            opcion = Int32.Parse("" + Session["insertar"]);


            if (opcion == 0 && !this.IsPostBack)//Si estamos en modo modificar y es primera vez que carga la pagina
            {
                //Guardado de la imagen original

                temp = logica.BuscarEvento(long.Parse(Session["EId"] + ""))[0];
                titulo_txt.Value = temp[2].ToString();
                descripcion_txt.Value = temp[4].ToString();

                Session["imgTemp"] = (byte[])temp[1];

            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string temp = "";
            int id = 0;

            //Validacion de fecha

            DateTime tS = DateTime.Parse(fecha_txt.Value + " " + hora_txt.Value);//fecha elegida
            DateTime now = DateTime.Now; //fecha actual

            if (DateTime.Compare(tS,now) < 0)//Si la fecha elegida es mas temprana que la actual
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La hora del evento es anterior a la actual. No se admiten eventos ya ocurridos. Vuelva a intentarlo con una fecha posterior. Tiene que volver a subir la imagen si ya habia subido una');", true);
                return;//fin
            }

            //Validación imagen
            byte[] img = null;
            if (img_fld.PostedFile != null && img_fld.FileBytes.Length > 1)//Si se selecciono una imagen nueva
            {

                if (Math.Round(((decimal)img_fld.PostedFile.ContentLength / (decimal)1024), 2) > 2048)//Copeoacion tamaño no mayor a 2mb
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La imagen no puede superar el peso de 2mb, por favor comprima la imagen o pruebe una imagen diferente');", true);
                    return;//fin
                }

                img = img_fld.FileBytes;//se asigna la imagen a agregar/modificar

            }
            else//Si el input de la imagen no tenia nada
            {
                if (Session["imgTemp"] != null)//si habia una imagen original de antemano
                {
                    img = (byte[])Session["imgTemp"];//se asigna la imagen oiriginal para modificar y asi no perderla

                }
            }

            string s;

            if (opcion == 0)//Si estamos en modo modificar
            {
                temp = Session["EId"].ToString();//Optenemos variable con ID de BD de evento
                id = Int32.Parse(temp);

                //Modificamos con la capa logica
                s = logica.ModificarEvento(id, titulo_txt.Value, descripcion_txt.Value, img, DateTime.Parse(fecha_txt.Value + " " + hora_txt.Value));

                //Mensaje
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+s+"');", true);
            }
            else//Si estamos en modo insertar
            {
                //Se inserta con la capa logica
                s = logica.InsertarEvento(titulo_txt.Value, descripcion_txt.Value, img, DateTime.Parse(fecha_txt.Value+" "+hora_txt.Value));
                
                //Mensaje
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);


                //Limpiamos todos los campos por si se quiere ingresar más eventos y no tener que borrarlos manualmente (solo con insertar)
                titulo_txt.Value = "";
                descripcion_txt.Value = "";

                DateTime t = DateTime.Now;

                string month;

                if (t.Month < 10)
                {
                    month = "0" + t.Month;
                }
                else
                {
                    month = "" + t.Month;
                }

                fecha_txt.Attributes.Add("min", "" + t.Year + "-" + month + "-" + t.Day);//limpiar datos hora

                fecha_txt.Value = t.Year + "-" + month + "-" + t.Day;

                hora_txt.Value = (t.Hour+1) + ":" + t.Minute;//Limpiar datos string

                img_fld = new FileUpload();//limpiar datos imagen

                //fin de limpiar datos

            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdministrarEventos.aspx");

        }
    }
}