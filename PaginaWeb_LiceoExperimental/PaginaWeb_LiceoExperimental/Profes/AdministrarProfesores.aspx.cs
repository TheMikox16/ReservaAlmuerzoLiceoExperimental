using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PaginaWeb_LiceoExperimental.Profes
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases AdministrarEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class AdministrarProfesores : System.Web.UI.Page
    {
        private LogicaProfesores logica = new LogicaProfesores();
        private string v = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            int n = int.Parse(Session["rol"] + "");

            if (n == 1 && n == 3)
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

            v = Request.QueryString["ver"];



            if (v != null && v.Equals("1"))
            {
                Session["PId"] = Request.QueryString["PId"];
                Session["ver"] = 0;
                Session["insertar"] = 0;
                Response.Redirect("FormularioProfesor.aspx");
            }
            else if (v != null && v.Equals("2"))
            {
                Session["PId"] = Request.QueryString["PId"];
                Session["ver"] = 0;
                Session["insertar"] = 0;
                string s = logica.EliminarProfesor(Int32.Parse(Request.QueryString["PId"] + ""));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);
            }

            if (!this.IsPostBack)
            {
                cancelar_btn.Visible = false;
            }


        }

        public string DataGridCreation()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();

            DataTable table = new DataTable();
            table.Columns.Add("Imagen", typeof(Object));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Eliminar", typeof(string));
            table.Columns.Add("Modificar", typeof(string));


            List<Object[]> list;

            if (Session["opt"] != null && Session["opt"].ToString().Equals("1"))
            {
                list = logica.BuscarProfesorNombre(buscar_txt.Value);
            }
            else
            {
                list = logica.ListarProfesores();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            foreach (Object[] temp in list)
            {
                if (temp[1] != null)
                {
                    var r = Convert.ToBase64String((byte[])temp[1]);
                    string s1 = String.Format("data:image;base64,{0}", r);
                    table.Rows.Add(s1, temp[2]);

                }
                else
                {

                    table.Rows.Add(temp[1], temp[2]);
                }
            }

            //strHTMLBuilder.Append("<table id=\"dtBasicExample\" class=\"table table - striped table - bordered\" cellspacing=\"0\" width=\"80%\">");

            strHTMLBuilder.Append("<thead><tr >");
            foreach (DataColumn myColumn in table.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }

            strHTMLBuilder.Append("</tr></thead><tbody>");

            bool s;
            byte[] f = null;


            int i = -1;
            int temp2 = -1;

            foreach (DataRow myRow in table.Rows)
            {
                f = null;

                i++;
                temp2 = -1;

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in table.Columns)
                {

                    if (myColumn.ColumnName.Equals("Modificar"))
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (int)list[i][0];
                        strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?PId=" + temp2 + "&ver=1\">Modificar</a>");

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Eliminar"))
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (int)list[i][0];
                        strHTMLBuilder.Append("<a ID=\"el\" type=\"button\" runat=\"server\" class=\"btn btn-danger\" href=\"?PId=" + temp2 + "&ver=2\" onclick=\"return confirm('¿Realmente desea borrar este profesor? (todas las secciones asociadas pasaran a \"No asignar\"')\">Eliminar</a>");

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Imagen") && myRow[myColumn.ColumnName].ToString().Length > 0)
                    {

                        strHTMLBuilder.Append("<td style='width:100px;'><img src='");
                        strHTMLBuilder.Append((string)myRow[myColumn.ColumnName]);
                        strHTMLBuilder.Append("' style='max-height:100%; max-width:100%'/></td>");

                        //Imagen.ImageUrl = (string)myRow[myColumn.ColumnName];

                    }
                    else
                    {
                        strHTMLBuilder.Append("<td >");
                        strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                        strHTMLBuilder.Append("</td>");
                    }



                }
                strHTMLBuilder.Append("</tr>");



            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            return strHTMLBuilder.ToString();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "1";
            cancelar_btn.Visible = true;
            buscar_btn.Visible = false;
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            cancelar_btn.Visible = false;
            buscar_btn.Visible = true;
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            Session["insertar"] = "1";
            cancelar_btn.Visible = false;
            buscar_btn.Visible = true;
            Response.Redirect("FormularioProfesor.aspx");

        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            Response.Redirect("Profes.aspx");
        }
    }
}