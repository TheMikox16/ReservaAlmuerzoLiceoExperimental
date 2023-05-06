using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Noticias
{


    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases DetallesEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */


    public partial class DetallesNoticia : System.Web.UI.Page
    {

        private LogicaNoticias logica = new LogicaNoticias();
        private int opcion = 0;
        private List<Object[]> temp;
        private Object[] temp2;
        private byte[] docTemp = null;



        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["NId"] == null || (Session["NId"] + "").Equals(""))
            {
                Response.Redirect("Noticias.aspx");
            }

            temp = logica.BuscarNoticia(long.Parse((String)Session["NId"]));

            temp2 = temp[0];

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image img;

            if (temp2[1] != null)
            {
                var r = Convert.ToBase64String((byte[])temp2[1]);
                string s = String.Format("data:image;base64,{0}", r);
                imgn_fld.Attributes["src"] = s;
            }

            titulo_h.InnerText = temp2[2].ToString();
            //titulo_lbl.InnerText = temp2[2].ToString();
            fecha_lbl.InnerText = temp2[3].ToString();
            descripcion_lbl.InnerText = temp2[4].ToString();
            if(temp2[5] != null)
            {
                docTemp = (byte[])temp2[5];
                file_btn.Visible = true;
                Session["doc"] = (byte[])temp2[5];
            }
            else
            {
                file_btn.Visible = false;
            }
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["NId"] = null;
            Response.Redirect("Noticias.aspx");
        }

        protected void Descargar_Click(object sender, EventArgs e)
        {
            byte[] file = docTemp;

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + titulo_h.InnerText + ".pdf");
            Response.BinaryWrite(file);
            Response.Flush();
            Response.End();
        }
    }
}