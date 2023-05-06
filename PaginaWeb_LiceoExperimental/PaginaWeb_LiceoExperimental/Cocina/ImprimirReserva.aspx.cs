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
    public partial class ImprimirReserva : System.Web.UI.Page
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
        }

        public string DataGridCreation()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();

            DataTable table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Identificador", typeof(string));
            table.Columns.Add("Fecha", typeof(string));
            table.Columns.Add("Entregado", typeof(string));


            List<Object[]> list = null;

            list = logica.ListarReservas();



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

                    if (myColumn.ColumnName.Equals("Entregar"))
                    {
                        if (myRow["Entregado"].ToString().Equals("Si"))
                        {
                            strHTMLBuilder.Append("<td >");
                            strHTMLBuilder.Append("Entregado");

                            strHTMLBuilder.Append("</td>");
                        }
                        else
                        {
                            strHTMLBuilder.Append("<td >");
                            temp2 = int.Parse(list[i][0] + "");
                            strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?ReservaId=" + temp2 + "&ver=1\">Entregar</a>");

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


        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaReservas.aspx");
        }

    }
}