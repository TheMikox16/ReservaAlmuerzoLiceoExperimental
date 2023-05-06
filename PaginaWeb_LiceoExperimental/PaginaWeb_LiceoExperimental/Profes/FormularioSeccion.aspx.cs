using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace PaginaWeb_LiceoExperimental.Profes
{
    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases FormularioEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */

    public partial class FormularioSeccion : System.Web.UI.Page
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
                temp = logica.ConsultarSeccion(Int32.Parse(Session["SId"] + ""))[0];
                nombre_txt.Value = temp[1].ToString();
                Session["SPId"] = temp[2].ToString();

            }

            if (!this.IsPostBack)
            {
                List<Object[]> list = logica.ListarProfesores();
                foreach (Object[] l in list)
                {
                    profesor_opt.Items.Add(new ListItem(l[2] + "", l[0] + ""));
                }
            }
                

        }

        

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string temp = "";
            int id = 0;


            string s;
            if (opcion == 0)
            {
                temp = Session["SId"].ToString();
                id = Int32.Parse(temp);

                s = logica.ModificarSeccion(id, nombre_txt.Value, Int32.Parse(profesor_opt.Value));

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);
            }
            else
            {
                s = logica.InsertarSeccion(nombre_txt.Value, Int32.Parse(profesor_opt.Value));

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);

                profesor_opt.SelectedIndex = 0;

                nombre_txt.Value = "";
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarSecciones.aspx");
        }
    }
}