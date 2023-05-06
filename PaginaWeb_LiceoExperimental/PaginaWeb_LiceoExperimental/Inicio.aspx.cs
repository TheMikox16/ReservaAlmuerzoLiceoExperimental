using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");
            }

            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 5)
            {
                usuario_img.Visible = true;
            }
            else
            {
                usuario_img.Visible = false;
            }

            Almuerzo();
        }

        protected void Almuerzo()
        {
            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 1)
            {
                //Estudiante
                almuerzo_b.HRef = "Cocina/Reserva.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    almuerzo_b.HRef = "Cocina/Menu.aspx";
                }
                else
                {
                    //estudiante
                    almuerzo_b.HRef = "Cocina/Reserva.aspx";
                }

            }
            else if (n == 3)
            {
                almuerzo_b.HRef = "Cocina/Menu.aspx";

            }
            else
            {
                almuerzo_b.HRef = "Cocina/Menu.aspx";

            }
        }
    }
}