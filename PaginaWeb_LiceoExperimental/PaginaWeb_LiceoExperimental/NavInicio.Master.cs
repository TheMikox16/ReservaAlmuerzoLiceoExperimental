using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental
{
    public partial class NavInicio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("Login.aspx");
            }

            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 5)
            {
                usuarios_a.Visible = true;
            }
            else
            {
                usuarios_a.Visible = false;
            }

            Almuerzo_Click();
            Noticias_Click();
            Eventos_Click();
            Profesores_Click();

        }


        protected bool Usuarios_Click(object sender, EventArgs e)
        {
            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 5 || (n == 2 && p))
            {
                return true;
            }
            return false;
        }


        protected void Noticias_Click()
        {
            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 1 || n == 3)
            {
                //Estudiante
                noticias_a.HRef = "Noticias/Noticias.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    noticias_a.HRef = "Noticias/Noticias.aspx";
                }
                else
                {
                    //estudiante
                    noticias_a.HRef = "Noticias/Noticiasaspx";
                }
            }
            else
            {
                noticias_a.HRef = "Noticias/Noticias.aspx";

            }
        }

        protected void Eventos_Click()
        {
            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 1 || n == 3)
            {
                //Estudiante
                eventos_a.HRef = "Eventos/Eventos.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    eventos_a.HRef = "Eventos/Eventos.aspx";
                }
                else
                {
                    //estudiante
                    eventos_a.HRef = "Eventos/Eventos.aspx";
                }
            }
            else
            {
                eventos_a.HRef = "Eventos/Eventos.aspx";

            }
        }

        protected void Profesores_Click()
        {
            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 1 || n == 3)
            {
                //Estudiante
                profesores_a.HRef = "../Profes/Profes.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    profesores_a.HRef = "../Profes/Profes.aspx";
                }
                else
                {
                    //estudiante
                    profesores_a.HRef = "../Profes/Profes.aspx";
                }
            }
            else
            {
                profesores_a.HRef = "../Profes/Profes.aspx";

            }
        }

        protected void Almuerzo_Click()
        {
            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 1)
            {
                //Estudiante
                almuerzo_a.HRef = "Cocina/Reserva.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    almuerzo_a.HRef = "Cocina/Menu.aspx";
                }
                else
                {
                    //estudiante
                    almuerzo_a.HRef = "Cocina/Reserva.aspx";
                }

            }
            else if (n == 3)
            {
                almuerzo_a.HRef = "Cocina/Menu.aspx";

            }
            else
            {
                almuerzo_a.HRef = "Cocina/Menu.aspx";

            }
        }

        
    }
}