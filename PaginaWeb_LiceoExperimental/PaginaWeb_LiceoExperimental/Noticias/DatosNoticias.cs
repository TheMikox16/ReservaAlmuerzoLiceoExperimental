using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb_LiceoExperimental.Noticias
{

    //NOTA: si se desea saber que hace cada metodo, por favor ver DatosEventos.cs en la carpeta de eventos ya que 
    //todos los procesos son reutilizados aqui con la diferencia de que hay parametros para Noticias

    public class DatosNoticias
    {

        private NoticiasEntities entity = new NoticiasEntities();

        public List<ListarNoticias_Result> ListarNoticias()
        {
            using (entity = new NoticiasEntities())
            {
                List<ListarNoticias_Result> busqueda = entity.ListarNoticias().ToList();

                return busqueda;

            }

        }
        
        public List<ConsultarNoticia_ID_Result> BuscarNoticia(long id)
        {
            using (entity = new NoticiasEntities())
            {
                List<ConsultarNoticia_ID_Result> busqueda = entity.ConsultarNoticia_ID(id).ToList();

                return busqueda;

            }


        }

        public List<ListarTodasNoticias_Result> ListarTodasNoticias()
        {
            using (entity = new NoticiasEntities())
            {
                List<ListarTodasNoticias_Result> busqueda = entity.ListarTodasNoticias().ToList();

                return busqueda;

            }

        }

        public List<ConsultarNoticia_PorTitulo_Result> BuscarNoticiaTitulo(string titulo)
        {
            using (entity = new NoticiasEntities())
            {
                List<ConsultarNoticia_PorTitulo_Result> busqueda = entity.ConsultarNoticia_PorTitulo(titulo).ToList();

                return busqueda;

            }

        }

        public bool BorrarNoticia(long id)
        {
            try
            {
                using (entity = new NoticiasEntities())
                {
                    entity.EliminarNoticia(id);

                    List<Noticia> l = entity.Noticia.Where(a => a.NoticiaID == id).ToList();

                    if (l.Count() > 0)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ModificarNoticia(long id, string titulo, string descripcion, byte[] img, byte[] arch)
        {

            try
            {
                using (entity = new NoticiasEntities())
                {
                    entity.Modificar_Noticia(id, titulo, descripcion, img, arch);

                    List<Noticia> l = entity.Noticia.Where(a => a.NoticiaID == id).ToList();

                    if (l[0].Titulo.Equals(titulo) && l[0].Descripcion.Equals(descripcion))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool InsertarNoticia(string titulo, string descripcion, byte[] img, byte[] arch)
        {
            try
            {
                using (entity = new NoticiasEntities())
                {
                    entity.Agregar_Noticia(titulo, descripcion, img, arch);


                    List<Noticia> l = entity.Noticia.ToList();

                    if (l[l.Count() - 1].Titulo.Equals(titulo) && l[l.Count() - 1].Descripcion.Equals(descripcion))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}