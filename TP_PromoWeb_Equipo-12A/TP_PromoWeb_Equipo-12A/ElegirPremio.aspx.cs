using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicio;

namespace TP_PromoWeb_Equipo_12A
{
    public partial class ElegirPremio : System.Web.UI.Page
    {
        //Me traigo los art para elegir uno
        public List<Articulo> ListaArticulos;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloServicio servicio = new ArticuloServicio();
            ListaArticulos = servicio.listar();

            //Valido antes de cargar eb el repeater, no se si es lo mas correcto pero funciona 
            foreach (var articulo in ListaArticulos)
            {
                if (articulo.Imagenes == null)
                    articulo.Imagenes = new List<Imagen>();

                //Y asigno una img por def
                if (articulo.Imagenes.Count == 0)
                {
                    Imagen imagen = new Imagen();
                    imagen.ImagenUrl = "https://cdn-icons-png.freepik.com/512/12048/12048902.png";
                    articulo.Imagenes.Add(imagen);
                }
                
            }

            rptArticulo.DataSource = ListaArticulos;
            rptArticulo.DataBind();

            //rptImagenes

        }
    }
}