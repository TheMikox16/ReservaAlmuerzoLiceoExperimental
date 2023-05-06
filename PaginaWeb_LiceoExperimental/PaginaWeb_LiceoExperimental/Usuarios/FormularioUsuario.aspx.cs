using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Usuarios
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases FormularioEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        private LogicaAdminUsuarios logica = new LogicaAdminUsuarios();
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
                temp = logica.ConsultarUsuario(long.Parse(Session["UId"] + ""))[0];

                correo_electronico_txt.Value = temp[1].ToString();
                nombre_txt.Value = temp[2].ToString();
                irlName_txt.Value = temp[3].ToString();
                apellido1_txt.Value = temp[4].ToString();
                if(temp[5] != null)
                {
                    apellido2_txt.Value = temp[5].ToString();
                }
                contrasenna_txt.Value = temp[6].ToString();

                int ntemp = Int32.Parse(temp[7] + "");

                rol_opt.SelectedIndex = ntemp;
                genero_opt.SelectedIndex = Int32.Parse(temp[10] + "") - 1;

                id_txt.Value = temp[11].ToString();
                id_opt.SelectedIndex = Int32.Parse(temp[12] + "") - 1;

                phone_txt.Value = temp[13].ToString();

                if (Boolean.Parse(temp[8] + "") && ntemp == 1)
                {
                    beca_opt.SelectedIndex = 1;
                }
                else
                {
                    beca_opt.SelectedIndex = 0;
                }

                if (Boolean.Parse(temp[9] + "") && ntemp == 2)
                {
                    beca_opt.SelectedIndex = 1;
                }
                else
                {
                    beca_opt.SelectedIndex = 0;
                }
            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string temp = "";
            int id = 0;
            bool becaTemp = false;
            bool permisoTemp = false;

            if(rol_opt.SelectedIndex == 1 && beca_opt.SelectedIndex == 1)
            {
                becaTemp = true;
            }

            if (rol_opt.SelectedIndex == 2 && permiso_opt.SelectedIndex == 1)
            {
                permisoTemp = true;
            }

            string s;

            if (opcion == 0)
            {
                temp = Session["UId"].ToString();
                id = Int32.Parse(temp);

                s = logica.ModificarUsuario(id, correo_electronico_txt.Value, nombre_txt.Value, contrasenna_txt.Value, confirm_txt.Value, (byte) rol_opt.SelectedIndex, becaTemp, permisoTemp, irlName_txt.Value, apellido1_txt.Value, apellido2_txt.Value, genero_opt.SelectedIndex+1, id_txt.Value, id_opt.SelectedIndex+1, phone_txt.Value);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + s + "')", true);

            }
            else
            {
                s = logica.InsertarUsuario(correo_electronico_txt.Value, nombre_txt.Value, contrasenna_txt.Value, confirm_txt.Value, (byte)rol_opt.SelectedIndex, becaTemp, permisoTemp, irlName_txt.Value, apellido1_txt.Value, apellido2_txt.Value, genero_opt.SelectedIndex + 1, id_txt.Value, id_opt.SelectedIndex + 1, phone_txt.Value);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + s + "')", true);


                correo_electronico_txt.Value = ""; 
                nombre_txt.Value = ""; 
                contrasenna_txt.Value = ""; 
                confirm_txt.Value = "";
                rol_opt.SelectedIndex = 0; 
                beca_opt.SelectedIndex = 0;
                permiso_opt.SelectedIndex = 0;
                irlName_txt.Value = ""; 
                apellido1_txt.Value = ""; 
                apellido2_txt.Value = "";
                genero_opt.SelectedIndex = 0; 
                id_txt.Value = "";
                id_opt.SelectedIndex = 0;
                phone_txt.Value = "";
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ListaUsuarios.aspx");
            
        }
    }
}