using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicio
{
    public class ArticuloServicio
    {
        public List<Articulo> listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenServicio im = new ImagenServicio();

            try
            {
                datos.setConsulta("SELECT A.id, A.Codigo, A.Descripcion, A.Nombre, A.Precio, M.Id as IdMarca, M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON M.Id = A.IdMarca LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    Categoria cat = new Categoria();
                    Marca marca = new Marca();
                    List<Imagen> imagenes = new List<Imagen>();

                    art.IdArticulo = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Precio = (decimal)datos.Lector["Precio"];

                    art.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        art.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                        art.Categoria.Descripcion = (string)datos.Lector["categoria"];
                    }
                    else
                    {
                        art.Categoria.IdCategoria = 0;
                        art.Categoria.Descripcion = "Sin categoría";
                    }

                    art.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        art.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                        art.Marca.Descripcion = (string)datos.Lector["marca"];
                    }
                    else
                    {
                        art.Marca.IdMarca = 0;
                        art.Marca.Descripcion = "Sin marca";
                    }

                    art.Imagenes = im.getImagenesIdArticulo(art.IdArticulo);
                    articulos.Add(art);
                }
                return articulos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
