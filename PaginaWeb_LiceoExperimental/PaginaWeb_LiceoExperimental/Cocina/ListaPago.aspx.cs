using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PaginaWeb_LiceoExperimental.Cocina
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases AdministrarEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */

    public partial class ListaPago : System.Web.UI.Page
    {
        private LogicaCocina logica = new LogicaCocina();
        private string id;

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

            id = Request.QueryString["NBId"];

            if (id != null && !id.Equals(""))//reserva de admin
            {
                if (!logica.VerificarPlatoDia())//Determina si ya hay un almuerzo del dia
                {
                    logica.ReservarAdmin(long.Parse(id));
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Aún no puede hacer reservas porque no se ha seleccionado un almuerzo para el día de hoy/mañana. Por favor intente más tarde')", true);//Muestra mensaje de error o confirmación
                }
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
            table.Columns.Add("Identificador", typeof(string));
            table.Columns.Add("Reservar", typeof(string));


            List<Object[]> list = null;

            if (Session["opt"] != null && Session["opt"].ToString().Equals("1") && rad1.Checked)//Si opt = 1 y nombre esta check
            {
                list = logica.BuscarNoBecados(buscar_txt.Value);
            }
            else if (Session["opt"] != null && Session["opt"].ToString().Equals("1") && rad2.Checked)//Si opt = 1 y id esta check
            {
                list = logica.BuscarNoBecadosID(buscar_txt.Value);
            }
            else
            {
                list = logica.ListarNoBecados();//Si opt != 1
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            string tempS;

            foreach (Object[] temp in list)
            {
                table.Rows.Add(temp[1], temp[2], temp[3]);
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

                    if (myColumn.ColumnName.Equals("Reservar"))//Boton para reservar a los que ya pagaron
                    {
                        
                            strHTMLBuilder.Append("<td >");
                            temp2 = int.Parse(list[i][0]+"");
                            strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?NBId=" + temp2 + "&ver=1\" onclick=\"return confirm('¿Seguro/a que desea reservar para esta persona?')\">Reservar</a>");

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

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            Response.Redirect("Menu.aspx");
        }
    }
}