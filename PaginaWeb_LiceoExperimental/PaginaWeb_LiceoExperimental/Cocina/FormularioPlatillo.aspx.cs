using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PaginaWeb_LiceoExperimental.Cocina
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases FormularioEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class FormularioPlatillo : System.Web.UI.Page
    {
        private LogicaCocina logica = new LogicaCocina();
        private int opcion = -1;
        private Object[] temp;

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

            opcion = Int32.Parse("" + Session["insertar"]);
            
            
            if(opcion == 0 && !this.IsPostBack)//validacion de disponible en modo modificar
            {
                temp = logica.BuscarPlatilloID(Int32.Parse(Session["Id"] + ""))[0];
                nombre_txt.Value = temp[2].ToString();
                descripcion_txt.Value = temp[3].ToString();

                Session["imgTemp"] = (byte[])temp[1];
                if(Boolean.Parse(temp[4] + ""))
                {
                    id_opt.SelectedIndex = 0;
                }
                else
                {
                    id_opt.SelectedIndex = 1;
                }
            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string temp = "";
            int id = 0;

            //Validacion imagen
            byte[] img;
            if (img_fld.PostedFile != null && img_fld.FileBytes.Length > 1)
            {
                if (Math.Round(((decimal)img_fld.PostedFile.ContentLength / (decimal)1024), 2) > 2048)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La imagen no puede superar el peso de 2mb, por favor comprima la imagen o pruebe una imagen diferente');", true);
                    return;
                }

                img = img_fld.FileBytes;

                /**string filename = Path.GetFileName(img_fld.PostedFile.FileName);
                using (Stream fs = img_fld.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        img = br.ReadBytes((Int32)fs.Length);
                    }
                }*/
            }
            else
            {
                img = (byte[])Session["imgTemp"];//imagen original
            }

            string s;

            if (opcion == 0)//modificar
            {
                temp = Session["Id"].ToString();//Id de BD de platillo
                id = Int32.Parse(temp);
                
                //Modificar
                s =logica.ModificarPlatillo(id, nombre_txt.Value, descripcion_txt.Value, img, id_opt.SelectedIndex);

                //Mensaje
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ s + "')", true);
            }
            else//Insertar
            {
                s = logica.InsertarPlatillo(nombre_txt.Value, descripcion_txt.Value, img, id_opt.SelectedIndex);


                //Mensaje
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + s + "')", true);


                //Reseteo de campos del formulario
                nombre_txt.Value = ""; 
                descripcion_txt.Value = "";
                img_fld = new FileUpload(); 
                id_opt.SelectedIndex = 0;
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            if (opcion == 0)
            {
                Response.Redirect("Detalles.aspx");
            }
            else
            {
                Response.Redirect("ListaAlmuerzos.aspx");
            }
        }

    }
}