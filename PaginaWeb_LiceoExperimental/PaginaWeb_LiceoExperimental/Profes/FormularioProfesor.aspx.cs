using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Profes
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases FormularioEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class FormularioProfesor : System.Web.UI.Page
    {
        private LogicaProfesores logica = new LogicaProfesores();
        private int opcion = -1;
        private Object[] temp;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["rol"] == null || Session["rol"].ToString().Equals(""))
            {
                Response.Redirect("../Login.aspx");
            }

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


            opcion = Int32.Parse("" + Session["insertar"]);


            if (opcion == 0 && !this.IsPostBack)
            {
                temp = logica.ConsultarProfesor(Int32.Parse(Session["PId"] + ""))[0];
                nombre_txt.Value = temp[2].ToString();
                apellido1_txt.Value = temp[4].ToString();
                apellido2_txt.Value = temp[5].ToString();
                descripcion_txt.Value = temp[6].ToString();
                correo_electronico_txt.Value = temp[7].ToString();
                phone_txt.Value = temp[8].ToString();

                Session["imgTemp"] = (byte[])temp[1];
                
            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string temp = "";
            int id = 0;

            byte[] img;
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
                img = (byte[])Session["imgTemp"];
            }

            string s;

            if (opcion == 0)
            {
                temp = Session["PId"].ToString();
                id = Int32.Parse(temp);

                s = logica.ModificarProfesor(id, descripcion_txt.Value, img, nombre_txt.Value, null, apellido1_txt.Value, apellido2_txt.Value, correo_electronico_txt.Value, phone_txt.Value);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);
            }
            else
            {
                s = logica.InsertarProfesor(descripcion_txt.Value, img, nombre_txt.Value, null, apellido1_txt.Value, apellido2_txt.Value, correo_electronico_txt.Value, phone_txt.Value);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);

                descripcion_txt.Value = "";
                nombre_txt.Value = "";
                apellido1_txt.Value = "";
                apellido2_txt.Value = "";
                correo_electronico_txt.Value = "";
                phone_txt.Value = "";

                img_fld = new FileUpload();

            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdministrarProfesores.aspx");

        }
    }
}