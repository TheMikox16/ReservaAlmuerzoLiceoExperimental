using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PaginaWeb_LiceoExperimental.Noticias
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases FormularioEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class FormularioNoticia : System.Web.UI.Page
    {
        private LogicaNoticias logica = new LogicaNoticias();
        private int opcion = -1;
        private Object[] temp;

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

            opcion = Int32.Parse("" + Session["insertar"]);


            if (opcion == 0 && !this.IsPostBack)
            {
                temp = logica.BuscarNoticia(long.Parse(Session["NId"] + ""))[0];
                titulo_txt.Value = temp[2].ToString();
                descripcion_txt.Value = temp[4].ToString();

                Session["imgTemp"] = (byte[])temp[1];
                Session["docTemp"] = (byte[])temp[5];

            }

        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string temp = "";
            int id = 0;

            
            byte[] img = null;
            if (img_fld.PostedFile != null && img_fld.FileBytes.Length > 1)
            {

                if (Math.Round(((decimal)img_fld.PostedFile.ContentLength / (decimal)1024), 2) > 2048)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La imagen no puede superar el peso de 2mb, por favor comprima la imagen o pruebe una imagen diferente');", true);
                    return;
                }

                img = img_fld.FileBytes;

            }
            else
            {
                if (Session["imgTemp"] != null)
                {
                    img = (byte[])Session["imgTemp"];

                }
            }

            byte[] doc = null;

            if (doc_fld.PostedFile != null && doc_fld.FileBytes.Length > 1)
            {

                if (Math.Round(((decimal)doc_fld.PostedFile.ContentLength / (decimal)1024), 2) > 10240)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El archivo no puede superar el peso de 10mb, por favor comprima el pdf o pruebe un archivo diferente');", true);
                    return;
                }

                string filename = Path.GetFileName(doc_fld.PostedFile.FileName);
                using (Stream fs = doc_fld.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        doc = br.ReadBytes((Int32)fs.Length);
                    }
                }
            }
            else
            {
                if (Session["docTemp"] != null)
                {
                    doc = (byte[])Session["docTemp"];
                    
                }
                
            }

            string s;

            if (opcion == 0)
            {
                temp = Session["NId"].ToString();
                id = Int32.Parse(temp);

                s = logica.ModificarNoticia(id, titulo_txt.Value, descripcion_txt.Value, img, doc);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);

            }
            else
            {
                s = logica.InsertarNoticia(titulo_txt.Value, descripcion_txt.Value, img, doc);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);

                titulo_txt.Value = "";
                descripcion_txt.Value = "";

                img_fld = new FileUpload();
                doc_fld = new FileUpload();
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            
             Response.Redirect("AdministrarNoticias.aspx");
            
        }
    }
}