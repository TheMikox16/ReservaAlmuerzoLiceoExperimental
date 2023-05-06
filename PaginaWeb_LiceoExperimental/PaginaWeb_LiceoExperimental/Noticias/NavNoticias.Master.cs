using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Noticias
{
    public partial class NavNoticias : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                //Response.Redirect("../Login.aspx");

                if (Session["rol"].ToString().Equals(""))
                {
                    usuarios_a.Visible = false;
                }
                else
                {
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
                }

                Almuerzo_Click();
                
                Profesores_Click();
            }
            else
            {
                almuerzo_a.Visible = false;
                profesores_a.Visible = false;
                usuarios_a.Visible = false;
                inicio_a.Visible = false;

            }
            Eventos_Click();


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



        protected void Eventos_Click()
        {
            if (Session["rol"] == null)
            {
                eventos_a.HRef = "../Eventos/Eventos.aspx";
                return;
            }

                int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 1 || n == 3)
            {
                //Estudiante
                eventos_a.HRef = "../Eventos/Eventos.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    eventos_a.HRef = "../Eventos/Eventos.aspx";
                }
                else
                {
                    //estudiante
                    eventos_a.HRef = "../Eventos/Eventos.aspx";
                }
            }
            else
            {
                eventos_a.HRef = "../Eventos/Eventos.aspx";

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
                almuerzo_a.HRef = "../Cocina/Reserva.aspx";
            }
            else if (n == 2)
            {
                if (p)
                {
                    almuerzo_a.HRef = "../Cocina/Menu.aspx";
                }
                else
                {
                    //estudiante
                    almuerzo_a.HRef = "../Cocina/Reserva.aspx";
                }

            }
            else if (n == 3)
            {
                almuerzo_a.HRef = "../Cocina/Menu.aspx";

            }
            else
            {
                almuerzo_a.HRef = "../Cocina/Menu.aspx";

            }
        }
    }
}
