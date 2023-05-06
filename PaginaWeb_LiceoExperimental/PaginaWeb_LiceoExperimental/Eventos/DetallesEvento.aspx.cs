using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Eventos
{
    public partial class DetallesEvento : System.Web.UI.Page
    {
        private LogicaEventos logica = new LogicaEventos();
        private int opcion = 0;
        private List<Object[]> temp;
        private Object[] temp2;
        private byte[] imgTemp = null;

        //Esta simple pagina solo carga los datos de Eventos y los despliega en pantalla

        //Existen varias pantallas en la aplicacion que funcionan como esta, solo que uno que otro valor o parametro debe ser
        //modificado para su correcto despliegue

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EId"] == null || (Session["EId"] + "").Equals(""))//Verifica si la variable de sesion no expiro, sino redirige a eventos
            {
                Response.Redirect("Eventos.aspx");
            }

            temp = logica.BuscarEvento(long.Parse((String)Session["EId"]));//Obtiene el ID de la BD del evento

            temp2 = temp[0];


            //Validacion de imagen
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            if (temp2[1] != null)//Si hay una imagen (no es nulo)
            {
                //Renderiza la imagen
                var r = Convert.ToBase64String((byte[])temp2[1]);
                string s = String.Format("data:image;base64,{0}", r);
                imgn_fld.Attributes["src"] = s;
            }

            //Asinación de las variables de la entrada obtenida para desplegarlos a la vista

            titulo_h.InnerText = temp2[2].ToString();
            //titulo_lbl.InnerText = temp2[2].ToString();
            fecha_lbl.InnerText = temp2[3].ToString();
            descripcion_lbl.InnerText = temp2[4].ToString();
        }

        //Un simple evento que regresa a la pagina anterior
        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["EId"] = null;//reinicio de variable de evento que se quiere ver
            Response.Redirect("Eventos.aspx");
        }
    }
}