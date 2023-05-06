using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace PaginaWeb_LiceoExperimental.Eventos
{
    public partial class Eventos : System.Web.UI.Page
    {
        LogicaEventos logica = new LogicaEventos();
        private string v = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString().Equals(""))
                {
                    admin_btn.Visible = false;
                }
                else
                {
                    int n = int.Parse(Session["rol"] + "");
                    bool p = bool.Parse(Session["permiso"] + "");
                    if (n == 5 || (n == 2 && p))
                    {
                        admin_btn.Visible = true;
                    }
                    else
                    {
                        admin_btn.Visible = false;
                    }
                }
            }
            else
            {
                admin_btn.Visible = false;
            }

            v = Request.QueryString["ver"];


            if (v != null && v.Equals("1"))
            {
                Session["EId"] = Request.QueryString["EId"];
                Response.Redirect("DetallesEvento.aspx"); //colocar Session["EId"] = null; en detalles noticia al regresar
            }

        }


        protected void Administrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarEventos.aspx");
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
         *  1-
         */
        public string DataGridCreation()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();

            List<Object[]> list;

            list = logica.ListarEventos();

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            foreach (Object[] temp in list)
            {
                strHTMLBuilder.Append("<div class=\"col-sm-4\">");

                strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn col-sm-12\" style=\"background-color: white; border: none;\" href=\"?EId=" + temp[0] + "&ver=1\">");

                if (temp[1] != null)
                {
                    var r = Convert.ToBase64String((byte[])temp[1]);
                    string s1 = String.Format("data:image;base64,{0}", r);
                    strHTMLBuilder.Append("<img class=\"col-sm-12\" src='");
                    strHTMLBuilder.Append(s1);
                    strHTMLBuilder.Append("' style='height:200px; width:100%'/>");
                    strHTMLBuilder.Append("<hr>");

                }
                else
                {
                    strHTMLBuilder.Append("<img class=\"col-sm-12\" src='' style='height:200px; width:100%'/>");
                    strHTMLBuilder.Append("<hr>");

                }

                strHTMLBuilder.Append("<h4 class=\"col-sm-12\" style=\"text-align: left; color: red;\">");
                strHTMLBuilder.Append(temp[2]);
                strHTMLBuilder.Append("</h4>");
                strHTMLBuilder.Append("<label class=\"col-sm-12\" style=\"text-align: left; font-size: 15px; color: blue;\">");
                strHTMLBuilder.Append(temp[3]);
                strHTMLBuilder.Append("</label>");


                strHTMLBuilder.Append("</a>");
                strHTMLBuilder.Append("</div>");

            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            return strHTMLBuilder.ToString();

        }
    }
}