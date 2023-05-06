using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental
{
    public partial class Resgistro : System.Web.UI.Page
    {

        LogicaUsuario logica = new LogicaUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            string s = logica.Registrar(correo_electronico_txt.Value, nombre_txt.Value, contrasenna_txt.Value, confirm_txt.Value, irlName_txt.Value, apellido1_txt.Value, apellido2_txt.Value, genero_opt.SelectedIndex, id_txt.Value, id_opt.SelectedIndex, phone_txt.Value);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + s + "')", true);

            if (s.Equals("Usuario registrado con éxito"))
            {
                correo_electronico_txt.Value = "";
                nombre_txt.Value = "";
                contrasenna_txt.Value = "";
                confirm_txt.Value = "";
                irlName_txt.Value = "";
                apellido1_txt.Value = "";
                apellido2_txt.Value = "";
                genero_opt.SelectedIndex = 0;
                id_txt.Value = "";
                id_opt.SelectedIndex = 0;
                phone_txt.Value = "";
            }
            
        }
    }
}