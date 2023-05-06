using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Noticias
{
    //NOTA: si se desea saber que hace cada metodo, por favor ver LogicaEventos.cs en la carpeta de eventos ya que 
    //todos los procesos son reutilizados aqui con la diferencia de que hay parametros para Noticias


    public class LogicaNoticias
    {
        private DatosNoticias datos = new DatosNoticias();

        public List<Object[]> ListarNoticias()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[6]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ListarNoticias_Result> ls = datos.ListarNoticias();//consulta capa datos

            foreach (ListarNoticias_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.NoticiaID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Titulo;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy") ;
                temp[4] = "" + p.Descripcion;
                temp[5] = p.Archivo;

                resultado.Add(temp);
            }

            return resultado;

        }

        public List<Object[]> BuscarNoticia(long id)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[6]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarNoticia_ID_Result> ls = datos.BuscarNoticia(id);//consulta capa datos

            foreach (ConsultarNoticia_ID_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.NoticiaID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Titulo;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy");
                temp[4] = "" + p.Descripcion;
                temp[5] = p.Archivo;
                resultado.Add(temp);
            }

            return resultado;

        }

        public List<Object[]> ListarTodasNoticias()
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ListarTodasNoticias_Result> ls = datos.ListarTodasNoticias();//consulta capa datos

            foreach (ListarTodasNoticias_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.NoticiaID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Titulo;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy");
                temp[4] = "" + p.Descripcion;
                resultado.Add(temp);
            }

            return resultado;

        }

        public List<Object[]> BuscarNoticiaTitulo(string titulo)
        {
            List<Object[]> resultado = new List<Object[]>(); //Creacion del array a pasar a tabla
            Object[] temp = new Object[5]; //Array para ir agregando filas a la variable resultado (que hara la tabla)

            List<ConsultarNoticia_PorTitulo_Result> ls = datos.BuscarNoticiaTitulo(titulo);//consulta capa datos

            foreach (ConsultarNoticia_PorTitulo_Result p in ls)
            {
                temp = new Object[10];

                temp[0] = p.NoticiaID;
                temp[1] = p.Imagen;
                temp[2] = "" + p.Titulo;
                temp[3] = "" + p.Fecha.ToString("dd/MM/yyyy");
                temp[4] = "" + p.Descripcion;
                resultado.Add(temp);
            }

            return resultado;

        }

        public string BorrarNoticia(long id)
        {
            if(datos.BorrarNoticia(id))
            {
                return "Noticia eliminada de forma éxitosa";
            }
            else
            {
                return "Error al eliminar noticia";
            }
        }

        public string ModificarNoticia(long id, string titulo, string descripcion, byte[] img, byte[] arch)
        {
            if(datos.ModificarNoticia(id, titulo, descripcion, img, arch))
            {
                return "Noticia modificada de forma éxitosa";
            }
            else
            {
                return "Error al modificar noticia";
            }
        }

        public string InsertarNoticia(string titulo, string descripcion, byte[] img, byte[] arch)
        {
            if(datos.InsertarNoticia(titulo, descripcion, img, arch))
            {
                return "Noticia creada de forma éxitosa";
            }
            else
            {
                return "Error al insertar noticia";
            }
        }
    }
}