using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Cocina
{
    public partial class Reserva : System.Web.UI.Page
    {
        private LogicaCocina logica = new LogicaCocina();
        private List<Object[]> temp;
        private Object[] temp2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");
            }

            if (!logica.VerificarPlatoDia())//Determina si ya hay un almuerzo del dia
            {
                //Si lo hay, carga todos los datos como si fuese Detalles.aspx

                temp = logica.BuscarPlatilloID(logica.ConsultarPlatoDia());

                temp2 = temp[0];

                if (temp2[1] != null)
                {
                    var r = Convert.ToBase64String((byte[])temp2[1]);
                    string s = String.Format("data:image;base64,{0}", r);
                    img_fld.Attributes["src"] = s;
                }

                titulo_lbl.InnerText = temp2[2].ToString();
                descripcion_lbl.InnerText = temp2[3].ToString();

            }
            else
            {
                //sino hay platillo del dia aun, se muestra un mensaje con esto

                titulo_lbl.InnerText = "Aun no se ha seleccionado un almuerzo. Vuelva más tarde por favor";
                reservar_btn.Visible = false;
            }
        }

        protected void Reservar_Click(object sender, EventArgs e)
        {
            //Proceso de reserva
            if (logica.VerificarHora())//Verifica que se pueda reservar a esta hora
            {
                string s = logica.Reservar(long.Parse(Session["PersonaID"] + ""));//Reserva

                string strAlert = "alert('" + s + "')";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", strAlert, true);//Muestra mensaje de error o confirmación
            }
            else//Hora de reserva no es correcta
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Los tiempos de reserva son de 4:00pm del dia anterior al almuerzo a 9:00am del dia del almuerzo');", true);
            }
        }
    }
}