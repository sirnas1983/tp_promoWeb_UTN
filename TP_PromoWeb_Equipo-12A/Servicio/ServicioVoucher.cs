using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicio
{
    public class ServicioVoucher
    {
        public bool asignarVoucher(int idCliente, int idArticulo, string voucher)
        {
            AccesoDatos datos = null;
            try
            {
                datos = new AccesoDatos();
                datos.setConsulta("UPDATE Vouchers SET idCliente = @idCliente, idArticulo = @idArticulo, fechaCanje = GETDATE() WHERE codigoVoucher = @voucher;");
                datos.setParametro("@idCliente", idCliente);
                datos.setParametro("@idArticulo", idArticulo);
                datos.setParametro("@voucher", voucher);
                datos.ejecutarLectura();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (datos != null)
                {
                    try
                    {
                        if (datos.Lector != null && !datos.Lector.IsClosed)
                            datos.Lector.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        public Voucher buscarVoucher(string cod)
        {
            AccesoDatos datos = null;
            try
            {
                datos = new AccesoDatos();
                datos.setConsulta("SELECT * FROM VOUCHERs WHERE codigoVoucher = @voucher");
                datos.limpiarParametros();
                datos.setParametro("@voucher", cod);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Voucher v = new Voucher();

                    if (datos.Lector["CodigoVoucher"] != DBNull.Value)
                        v.CodigoVoucher = datos.Lector["codigoVoucher"].ToString();
                    if (datos.Lector["idCliente"] != DBNull.Value)
                        v.IdCliente = (int)datos.Lector["idCliente"];
                    if (datos.Lector["idArticulo"] != DBNull.Value)
                        v.IdArticulo = (int)datos.Lector["idArticulo"];
                    if (datos.Lector["fechaCanje"] != DBNull.Value)
                        v.FechaCanje = (DateTime)datos.Lector["fechaCanje"];

                    return v;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos?.cerrarConexion();
            }
        }

        public bool voucherExiste(Voucher v)
        {
            return v != null;
        }

        public bool esVoucherCanjeable(Voucher v)
        {
            return v != null &&
                   v.IdCliente == 0 &&
                   v.IdArticulo == 0 &&
                   v.FechaCanje == default(DateTime);
        }

    }
}
