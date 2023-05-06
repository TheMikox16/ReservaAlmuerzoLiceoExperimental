using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PaginaWeb_LiceoExperimental.Usuarios
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases AdministrarEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        private LogicaAdminUsuarios logica = new LogicaAdminUsuarios();
        private string v = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");
            }

            int n = int.Parse(Session["rol"] + "");

            if (n == 1 || n == 3)
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
                Session["UId"] = Request.QueryString["UId"];
                Session["ver"] = 0;
                Session["insertar"] = 0;
                Response.Redirect("FormularioUsuario.aspx");
            }
            else if (v != null && v.Equals("2"))
            {
                Session["UId"] = Request.QueryString["UId"];
                Session["ver"] = 0;
                Session["insertar"] = 0;
                string s = logica.EliminarUsuario(long.Parse(Request.QueryString["UId"] + ""));
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
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Identificación", typeof(string));
            table.Columns.Add("Correo Electrónico", typeof(string));
            table.Columns.Add("Rol", typeof(string));
            table.Columns.Add("Permiso", typeof(string));
            table.Columns.Add("Modificar", typeof(string));
            table.Columns.Add("Eliminar", typeof(string));


            List<Object[]> list;

            if (Session["opt"] != null && Session["opt"].ToString().Equals("1"))
            {
                list = logica.BuscarUsuario(buscar_txt.Value);

            }
            else
            {
                list = logica.ListarUsuarios();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            foreach (Object[] temp in list)
            {
                table.Rows.Add(temp[1], temp[2], temp[3], temp[4], temp[5]);
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
            int rol;

            int i = -1;
            long temp2 = -1;

            foreach (DataRow myRow in table.Rows)
            {

                i++;
                temp2 = -1;

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in table.Columns)
                {

                    if (myColumn.ColumnName.Equals("Modificar"))
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (long)list[i][0];
                        strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?UId=" + temp2 + "&ver=1\">Modificar</a>");

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Eliminar") && long.Parse(Session["PersonaID"]+"") != (long)list[i][0])
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (long)list[i][0];
                        strHTMLBuilder.Append("<a ID=\"el\" type=\"button\" runat=\"server\" class=\"btn btn-danger\" href=\"?UId=" + temp2 + "&ver=2\" onclick=\"return confirm('¿Realmente desea borrar este usuario?')\">Eliminar</a>");

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Permiso"))
                    {
                        strHTMLBuilder.Append("<td >");

                        s = Boolean.Parse(myRow[myColumn.ColumnName] + "");
                        if (s)
                        {
                            strHTMLBuilder.Append("Si");
                        }
                        else
                        {
                            strHTMLBuilder.Append("No");
                        }

                        strHTMLBuilder.Append("</td>");

                    }
                    else if (myColumn.ColumnName.Equals("Rol"))
                    {
                        strHTMLBuilder.Append("<td >");

                        rol = Int32.Parse(myRow[myColumn.ColumnName] + "");
                        if (rol == 1)
                        {
                            strHTMLBuilder.Append("Estudiante");
                        }
                        else if (rol == 2)
                        {
                            strHTMLBuilder.Append("Profesor");
                        }
                        else if (rol == 3)
                        {
                            strHTMLBuilder.Append("Cocina");
                        }
                        else
                        {
                            strHTMLBuilder.Append("Administrador");
                        }

                        strHTMLBuilder.Append("</td>");

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
            Response.Redirect("FormularioUsuario.aspx");

        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            Response.Redirect("PaginaInicial.aspx");
        }
    }
}