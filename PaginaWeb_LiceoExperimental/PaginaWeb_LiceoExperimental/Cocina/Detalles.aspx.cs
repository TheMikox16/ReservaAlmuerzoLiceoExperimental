using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Cocina
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases DetallesEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */

    public partial class Detalles : System.Web.UI.Page
    {

        private LogicaCocina logica = new LogicaCocina();
        private int opcion = 0;
        private List<Object[]> temp;
        private Object[] temp2;
        private byte[] imgTemp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");
            }

            int n = int.Parse(Session["rol"] + "");

            if (n == 1)
            {
                Response.Redirect("../Login.aspx");
            }

            if (n == 2)
            {
                if (!bool.Parse(Session["permiso"] + ""))
                {
                    Response.Redirect("../Login.aspx");
                }
            }

            temp = logica.BuscarPlatilloID(Int32.Parse((String)Session["Id"]));//se busca la entrada en la BD de lo que se solicito ver

            temp2 = temp[0];

            //validacion de imagen

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            if (temp2[1] != null)//Cargamos la imagen segun lo que encontramos en la base de datos
            {
                var r = Convert.ToBase64String((byte[])temp2[1]);
                string s = String.Format("data:image;base64,{0}", r);
                imgn_fld.Attributes["src"] = s;
            }

            titulo_lbl.InnerText = temp2[2].ToString();
            descripcion_lbl.InnerText = temp2[3].ToString();
            //id_opt.SelectedIndex = Int32.Parse(temp2[4].ToString());
        }

        //Evniar a formulario en modo modificar
        protected void Modificar_Click(object sender, EventArgs e)
        {
            Session["insertar"] = 0;//modo modificar
            Response.Redirect("FormularioPlatillo.aspx");
        }

        //este boton borra el platillo, pero valida que no sea el platillo de dai
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            bool borrado = false;

            if(Int32.Parse((String)Session["Id"]) == logica.ConsultarPlatoDia())//Saca la entrada completa del plato del dia y ve si es la misa que la del plato actual
            {
                //Indica que no se puede borrar y se sale de al funcion
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('¡No puedes borrar el platillo del día!');", true);
                return;
            }
            
            //Si lo elimina si lo anterior no se cumple
            borrado = logica.EliminarPlatillo(Int32.Parse((String)Session["Id"]));

            if (borrado)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Borrado con Éxito');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error al Borrar');", true);
            }

            Session["ver"] = 0;
            Response.Redirect("ListaAlmuerzos.aspx");
        }

        //Este boton llama al comportamiento de seleccion de platillo
        protected void Seleccion_Click(object sender, EventArgs e)
        {
            bool seleccionado = logica.VerificarPlatoDia();//verificar si ya hay un platillo del dia

            bool disponible = logica.VerificarDisponible(Int32.Parse((String)Session["Id"]));

            if (!disponible)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No puede seleccionar un platillo que esta deshabilitado o no esta disponible');", true);
                return;
            }

            string s = "";
            if (!seleccionado)//en caso de que ya hubiese un platillo del dia
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ya se ha seleccionado el platillo del día');", true);
            }
            else//caso contrario
            {
                s = logica.SeleccionarAlmuerzoDia(Int32.Parse((String)Session["Id"]));//Se selecciona el platillo del dia
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+ s +"');", true);
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session["ver"] = 0;
            Response.Redirect("ListaAlmuerzos.aspx");
        }
    }
}