﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWeb_LiceoExperimental.Profes
{

    /**NOTA: Para entender el comportamiento de esta pagina, por favor ver la documentación de las clases DetallesEventos.aspx.cs,
          LogicaEventos.cs y DatosEventos.cs ya que el procedimiento basico es mas claro ahi y con ello se llega a el funcionamiento
            avanzado de esta y otras paginas
    */
    public partial class DetallesSeccion : System.Web.UI.Page
    {
        private LogicaProfesores logica = new LogicaProfesores();
        private List<Object[]> temp;
        private Object[] temp2;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["SId"] == null || (Session["SId"] + "").Equals(""))
            {
                Response.Redirect("Profes.aspx");
            }

            temp = logica.BuscarSeccion(Int32.Parse((String)Session["SId"]));

            temp2 = temp[0];

            if (temp2[1] != null)
            {
                var r = Convert.ToBase64String((byte[])temp2[1]);
                string s = String.Format("data:image;base64,{0}", r);
                img_fld.Attributes["src"] = s;
            }

            seccion_lbl.InnerText = "Sección: " + temp2[2].ToString();
            nombre_lbl.InnerText = "Nombre del Profesor Guía: \n" + temp2[3].ToString();
            descripcion_lbl.InnerText = "Descripción del profesor: \n" + temp2[4].ToString();
            correo_lbl.InnerText = "Correo: \n" + temp2[5].ToString();
            telefono_lbl.InnerText = "Teléfono: \n" + temp2[6].ToString();

        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Session["SId"] = null;
            Response.Redirect("Profes.aspx");

        }
    }
}