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
    public partial class Profes1 : System.Web.UI.Page
    {
        LogicaProfesores logica = new LogicaProfesores();
        private string v = "0";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");
            }
            

            int n = int.Parse(Session["rol"] + "");
            bool p = bool.Parse(Session["permiso"] + "");

            if (n == 5 || (n == 2 && p))
            {
                admin_btn.Visible = true;
                admin_btn2.Visible = true;

            }
            else
            {
                admin_btn.Visible = false;
                admin_btn2.Visible = false;
            }

            v = Request.QueryString["ver"];


            if (v != null && v.Equals("1"))
            {
                Session["PId"] = Request.QueryString["PId"];
                Response.Redirect("DetallesProfesor.aspx"); //colocar Session["NId"] = null; en detalles noticia al regresar
            }
            else if (v != null && v.Equals("2"))
            {
                Session["SId"] = Request.QueryString["SId"];
                Response.Redirect("DetallesSeccion.aspx"); //colocar Session["NId"] = null; en detalles noticia al regresar
            }

            if (!this.IsPostBack)
            {
                Session["opt1"] = "0";
                Session["opt2"] = "0";
                cancelar1_btn.Visible = false;
                cancelar2_btn.Visible = false;
            }

        }


        protected void Administrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarProfesores.aspx");
        }

        protected void Administrar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarSecciones.aspx");
        }

        public string DataGridCreation1()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();

            DataTable table = new DataTable();
            table.Columns.Add("Imagen", typeof(Object));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Detalles", typeof(string));


            List<Object[]> list;

            if (Session["opt1"] != null && Session["opt1"].ToString().Equals("1"))
            {
                list = logica.BuscarProfesorNombre(buscar1_txt.Value);
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

                    if (myColumn.ColumnName.Equals("Detalles"))
                    {
                        strHTMLBuilder.Append("<td >");
                        temp2 = (Int32)list[i][0];
                        strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?PId=" + temp2 + "&ver=1\">Ver</a>");

                        //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                        strHTMLBuilder.Append("</td>");
                    }
                    else if (myColumn.ColumnName.Equals("Imagen") && myRow[myColumn.ColumnName].ToString().Length > 0)
                    {

                        strHTMLBuilder.Append("<td style='width:100px; height:100px'><img src='");
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


        public string DataGridCreation2()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();

            DataTable table = new DataTable();
            table.Columns.Add("Sección", typeof(string));
            table.Columns.Add("Imagen", typeof(Object));
            table.Columns.Add("Profesor Guía", typeof(string));
            table.Columns.Add("Detalles", typeof(string));


            List<Object[]> list;

            if (Session["opt2"] != null && Session["opt2"].ToString().Equals("1"))
            {
                list = logica.ListarSeccionesDesc(buscar2_txt.Value);
            }
            else
            {
                list = logica.ListarSecciones();
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            foreach (Object[] temp in list)
            {
                if (temp[2] != null)
                {
                    var r = Convert.ToBase64String((byte[])temp[2]);
                    string s1 = String.Format("data:image;base64,{0}", r);
                    table.Rows.Add(temp[1], s1, temp[3]);

                }
                else
                {

                    table.Rows.Add(temp[1], temp[2], temp[3]);
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

            string control = "Profesor No Asignado Aún";

            foreach (DataRow myRow in table.Rows)
            {
                f = null;

                i++;
                temp2 = -1;

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in table.Columns)
                {

                    if (myColumn.ColumnName.Equals("Detalles"))
                    {
                        if (!list[i][3].Equals(control))
                        {
                            strHTMLBuilder.Append("<td >");
                            temp2 = (Int32)list[i][0];
                            strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?SId=" + temp2 + "&ver=2\">Ver</a>");

                            //strHTMLBuilder.Append("<a ID=\"mod\" type=\"button\" runat=\"server\" class=\"btn btn-secondary\" href=\"?Nombre=" + s + "&ver=1\">Ver</a>");
                            strHTMLBuilder.Append("</td>");
                        }
                    }
                    else if (myColumn.ColumnName.Equals("Imagen") && myRow[myColumn.ColumnName].ToString().Length > 0)
                    {

                        strHTMLBuilder.Append("<td style='width:80px; height:80px'><img src='");
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

        protected void Buscar1_Click(object sender, EventArgs e)
        {
            Session["opt1"] = "1";
            cancelar1_btn.Visible = true;
            buscar1_btn.Visible = false;
        }

        protected void Buscar2_Click(object sender, EventArgs e)
        {
            Session["opt2"] = "1";
            cancelar2_btn.Visible = true;
            buscar2_btn.Visible = false;
        }

        protected void Cancelar1_Click(object sender, EventArgs e)
        {
            Session["opt1"] = "0";
            cancelar1_btn.Visible = false;
            buscar1_btn.Visible = true;
        }

        protected void Cancelar2_Click(object sender, EventArgs e)
        {
            Session["opt2"] = "0";
            cancelar2_btn.Visible = false;
            buscar2_btn.Visible = true;
        }
    }
}