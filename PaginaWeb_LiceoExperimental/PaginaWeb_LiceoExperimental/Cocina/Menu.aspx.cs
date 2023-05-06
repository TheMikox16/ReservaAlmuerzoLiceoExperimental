using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Cocina
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
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
        }

        protected void Almuerzo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservaAdmin.aspx");
        }

        protected void Reservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaReservas.aspx");
        }

        protected void Pago_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPago.aspx");
        }

    }
}