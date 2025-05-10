using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicio
{
    public class ServicioCliente
    {
        public int IdCliente { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }


        public Cliente obtenerCliente(string dni)
        {
            AccesoDatos datos = null;
            Cliente cliente = new Cliente();

            try
            {
                datos = new AccesoDatos();
                datos.setConsulta("SELECT * FROM Clientes WHERE Documento = @dni");
                datos.setParametro("@dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.IdCliente = (int)datos.Lector["Id"];
                    cliente.Documento = (string)datos.Lector["DOCUMENTO"];
                    cliente.Nombre = (string)datos.Lector["NOMBRE"];
                    cliente.Apellido = (string)datos.Lector["APELLIDO"];
                    cliente.Email = (string)datos.Lector["EMAIL"];
                    cliente.Direccion = (string)datos.Lector["DIRECCION"];
                    cliente.Ciudad = (string)datos.Lector["CIUDAD"];
                    cliente.CodigoPostal = (int)datos.Lector["CP"];
                    return cliente;
                }

                return cliente;
            }
            catch (Exception)
            {
                return cliente;
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
                    catch { }
                    datos.cerrarConexion();
                }
            }
        }
        
        public int altaCliente(Cliente cliente)
        {
            AccesoDatos datos = null;
            try
            {
                datos = new AccesoDatos();
                datos.limpiarParametros();
                datos.setConsulta(" INSERT INTO Clientes (DOCUMENTO, NOMBRE, APELLIDO, EMAIL, DIRECCION, CIUDAD, CP) VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @codigoPostal); SELECT SCOPE_IDENTITY();");
                datos.setParametro("@documento", cliente.Documento);
                datos.setParametro("@nombre", cliente.Nombre);
                datos.setParametro("@apellido", cliente.Apellido);
                datos.setParametro("@email", cliente.Email);
                datos.setParametro("@direccion", cliente.Direccion);
                datos.setParametro("@ciudad", cliente.Ciudad);
                datos.setParametro("@codigoPostal", cliente.CodigoPostal);
                return int.Parse(datos.ejecutarEscalar().ToString());
            }
            catch (Exception)
            {
                return 0;
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
                    catch { }
                    datos.cerrarConexion();
                }
            }
        }

        public bool actualizarCliente(Cliente cliente)
        {
            AccesoDatos datos = null;
            try
            {
                datos = new AccesoDatos();
                datos.limpiarParametros();
                datos.setConsulta("UPDATE Clientes SET NOMBRE = @nombre, APELLIDO = @apellido, EMAIL = @email, DIRECCION = @direccion, CIUDAD = @ciudad, CP = @codigoPostal WHERE DOCUMENTO = @documento");
                datos.setParametro("@documento", cliente.Documento);
                datos.setParametro("@nombre", cliente.Nombre);
                datos.setParametro("@apellido", cliente.Apellido);
                datos.setParametro("@email", cliente.Email);
                datos.setParametro("@direccion", cliente.Direccion);
                datos.setParametro("@ciudad", cliente.Ciudad);
                datos.setParametro("@codigoPostal", cliente.CodigoPostal);
                datos.ejecutarAccion();
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
                    catch { }
                    datos.cerrarConexion();
                }
            }
        }


    }
}
