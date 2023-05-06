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
    public partial class ListaReservas : System.Web.UI.Page
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

            id = Request.QueryString["ReservaId"];

            if (id != null && !id.Equals(""))//Entrega de almuerzo a estudiante
            {
                bool b = logica.EntregarPlatillo(long.Parse(id));//Entrega

                if (!b)//verifica entrega
                {
                    //error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error al entregar platillo');", true);
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
            table.Columns.Add("Fecha", typeof(string));
            table.Columns.Add("Entregado", typeof(string));
            table.Columns.Add("Entregar", typeof(string));//boton


            List<Object[]> list = null;

            if (Session["opt"] != null && Session["opt"].ToString().Equals("1") && rad1.Checked)//si opt es 1 y nombre esta check
            {
                list = logica.BuscarReserva(buscar_txt.Value);
            }
            else if (Session["opt"] != null && Session["opt"].ToString().Equals("1") && rad2.Checked)//si opt es 1 y id esta check
            {
                list = logica.BuscarReservaID(buscar_txt.Value);
            }
            else if (Session["opt"] != null && Session["opt"].ToString().Equals("1") && rad3.Checked)//si opt es 1 y pendientes esta check
            {
                list = logica.ReservasPendientes();
            }
            else
            {
                list = logica.ListarReservas();//Si opt != 1 (no se busca)
            }

            string tempS;

            foreach (Object[] temp in list)
            {
                tempS = "No";

                if ((bool)temp[4])
                {
                    tempS = "Si";
                }

                table.Rows.Add(temp[1], temp[2], temp[3], tempS);
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

                    if (myColumn.ColumnName.Equals("Entregar"))
                    {
                        if (myRow["Entregado"].ToString().Equals("Si"))//Determina si ya se entrego un almuerzo a cierta persona, si es el caso se deshabilita el boton entregar
                        {
                            strHTMLBuilder.Append("<td >");
                            strHTMLBuilder.Append("Entregado");

                            strHTMLBuilder.Append("</td>");
                        }
                        else//Caso contrario, si no se ha entrregado se coloca boton entregar
                        {
                            strHTMLBuilder.Append("<td >");
                            temp2 = int.Parse(list[i][0]+"");
                            strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?ReservaId=" + temp2 + "&ver=1\" onclick=\"return confirm('¿Realmente desea entregar este almuerzo?')\">Entregar</a>");

                            strHTMLBuilder.Append("</td>");
                        }
                        
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

        protected void Imprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImprimirReserva.aspx");
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["opt"] = "0";
            Response.Redirect("Menu.aspx");
        }
    }
}