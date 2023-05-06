using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental
{
    public partial class Login : System.Web.UI.Page
    {

        LogicaUsuario logica = new LogicaUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["rol"] = null;
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            string[] l = logica.Ingresar(correo_electronico_txt.Value, contrasenna_txt.Value);


            if (!l[0].Equals("El usuario no fue encontrado. Inicio de sesión fallido"))
            {
                Session["PersonaID"] = l[0];
                if(l[1].Equals("0"))
                {
                    Session["rol"] = 5;
                }
                else
                {
                    Session["rol"] = l[1];
                }
                Session["uname"] = l[2];
                Session["permiso"] = l[3];
                

                Response.Redirect("Inicio.aspx");


                /**
                int r = int.Parse(l[1]);
                bool p = bool.Parse(l[3]);

                
                if (r == 1)
                {
                    Response.Redirect("Cocina/Reserva.aspx");//cambiar
                }
                else if (r == 2)
                {
                    if (p)
                    {
                        Response.Redirect("Cocina/Menu.aspx");//cambiar
                    }

                    Response.Redirect("Cocina/Reserva.aspx");//cambiar
                }
                else if (r == 3)
                {
                    Response.Redirect("Cocina/Menu.aspx");//cambiar?
                    //Cocina
                }
                else
                {
                    Response.Redirect("Cocina/Menu.aspx");//cambiar
                }*/
            }
            else
            {
                string strAlert = "alert('" + l[0] + "')";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", strAlert, true);
            }

        }

    }
}