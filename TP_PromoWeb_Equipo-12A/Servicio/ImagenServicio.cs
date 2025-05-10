using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicio
{
    public class ImagenServicio
    {
        public List<Imagen> getImagenesIdArticulo(int id)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT id, idArticulo, imagenURL FROM IMAGENES WHERE idArticulo = @id");
                datos.limpiarParametros();
                datos.setParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen im = new Imagen();
                    im.IdImagen = (int)datos.Lector["id"];
                    im.IdArticulo = (int)datos.Lector["idArticulo"];
                    im.ImagenUrl = (string)datos.Lector["imagenURL"];
                    imagenes.Add(im);
                }
                return imagenes;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }

}
