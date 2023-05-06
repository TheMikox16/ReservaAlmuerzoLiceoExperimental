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

    public partial class Becas : System.Web.UI.Page
    {

        private LogicaAdminUsuarios logica = new LogicaAdminUsuarios();
        private string id = "0";

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


            id = Request.QueryString["UsuarioId"] +"";//Determina si se eligio un usuario para cambiar su condicion de beca


            if (id != null && !id.Equals(""))
            {
                logica.ActualizarBeca(long.Parse(id+""));//actualiza una beca de un usuario
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
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Becado", typeof(string));
            table.Columns.Add("Cambiar Beca", typeof(string));//boton


            List<Object[]> list;

            if (Session["opt"] != null && Session["opt"].ToString().Equals("1"))
            {
                list = logica.BuscarEstudiante(buscar_txt.Value);
            }
            else
            {
                list = logica.ListarEstudiantes();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            string tempS;

            foreach (Object[] temp in list)
            {
                tempS = "No";

                if ((bool)temp[3])
                {
                    tempS = "Si";
                }

                table.Rows.Add(temp[1], temp[2], tempS);
                
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


            int i = -1;
            long temp2 = -1;

            foreach (DataRow myRow in table.Rows)
            {

                i++;
                temp2 = -1;

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in table.Columns)
                {

                    if (myColumn.ColumnName.Equals("Cambiar Beca"))
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = long.Parse(list[i][0]+"");
                        strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" onclick=\"return confirm('¿Realmente desea cambiar la beca de esta persona?')\" class=\"btn btn-secondary\" href=\"?UsuarioId=" + temp2 + "\">Cambiar</a>");

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
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
            Response.Redirect("FormularioPlatillo.aspx");

        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            Response.Redirect("PaginaInicial.aspx");
        }

    }
}