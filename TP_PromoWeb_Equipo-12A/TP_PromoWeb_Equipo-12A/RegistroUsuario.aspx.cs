using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicio;

namespace TP_PromoWeb_Equipo_12A
{
    public partial class RegistroUsuario : Page
    {
        private const int LongitudDNI = 8;
        private const int LongitudCP = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["voucher"] == null)
            {
                mostrarError("Error al asignar el voucher", "No se ingreso voucher. Por favor, intentelo nuevamente.");
            }
            else
            {
                hdnVoucher.Value = Session["voucher"].ToString();
            }
            if (!IsPostBack)
            {
                txtDni.Focus();
                hdnIdArticulo.Value = Request.QueryString["idArticulo"];
                
            }
        }

        protected void btnBuscarDni_Click(object sender, EventArgs e)
        {
            if (btnBuscarDni.Text.Equals("❌"))
            {
                Response.Redirect($"RegistroUsuario.aspx?idArticulo={hdnIdArticulo.Value}&voucher={hdnVoucher.Value}");
                return;
            }

            string dni = txtDni.Text.Trim();
            lblDni.Text = "";

            if (!(dni.Length == LongitudDNI || dni.Length == LongitudDNI - 1) || !dni.All(char.IsDigit))
            {
                lblDni.Text = "DNI inválido. Debe contener 8 dígitos numéricos.";
                return;
            }

            ServicioCliente servicioCliente = new ServicioCliente();
            Cliente cliente = servicioCliente.obtenerCliente(dni);

            hdnIdCliente.Value = cliente.IdCliente.ToString();

            if (cliente.IdCliente != 0)
                txtDni.ReadOnly = true;

            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtDireccion.Text = cliente.Direccion;
            txtCiudad.Text = cliente.Ciudad;
            txtCp.Text = cliente.CodigoPostal.ToString();

            setearSoloLectura(false);
            chkTerminos.Enabled = true;
            btnBuscarDni.Text = "❌";
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
                return;

            Cliente cliente = new Cliente
            {
                IdCliente = int.Parse(hdnIdCliente.Value),
                Documento = txtDni.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                Ciudad = txtCiudad.Text,
                CodigoPostal = int.Parse(txtCp.Text)
            };

            ServicioCliente servicioCliente = new ServicioCliente();
            bool exito = cliente.IdCliente == 0
                ? servicioCliente.altaCliente(cliente) != 0
                : servicioCliente.actualizarCliente(cliente);

            if (exito)
            {
                ServicioVoucher servicioVoucher = new ServicioVoucher();
                if (!string.IsNullOrEmpty(hdnVoucher.Value) &&
                    !string.IsNullOrEmpty(hdnIdArticulo.Value) &&
                    servicioVoucher.asignarVoucher(cliente.IdCliente, int.Parse(hdnIdArticulo.Value), hdnVoucher.Value))
                {
                    Session.Remove("voucher");
                    Response.Redirect("RegistroExitoso.aspx");
                }
                else
                {
                    mostrarError("Error al asignar el voucher", "No se pudo asignar el voucher al cliente. Por favor, intente nuevamente.");
                }
            }
            else
            {
                mostrarError("Error al actualizar el cliente", "No se pudo actualizar el cliente. Por favor, intente nuevamente.");
            }
        }

        private void setearSoloLectura(bool isReadOnly)
        {
            txtNombre.ReadOnly = isReadOnly;
            txtApellido.ReadOnly = isReadOnly;
            txtEmail.ReadOnly = isReadOnly;
            txtDireccion.ReadOnly = isReadOnly;
            txtCiudad.ReadOnly = isReadOnly;
            txtCp.ReadOnly = isReadOnly;
        }

        private bool validarFormulario()
        {
            bool err = false;

            err |= validarCampo(txtNombre, lblNombreError, "El nombre debe tener al menos 3 caracteres");
            err |= validarCampo(txtApellido, lblApellidoError, "El apellido debe tener al menos 3 caracteres");
            err |= validarMail(txtEmail, lblEmailError, "El email no cumple con el formato adecuado. Ingrese un email valido.");
            err |= validarCampo(txtDireccion, lblDireccionError, "La dirección debe tener al menos 3 caracteres");
            err |= validarCampo(txtCiudad, lblCiudadError, "La ciudad debe tener al menos 3 caracteres");

            if (txtCp.Text.Length != LongitudCP || !txtCp.Text.All(char.IsDigit))
            {
                lblCpError.Text = "El código postal debe tener 4 dígitos numéricos";
                err = true;
            }
            else
            {
                lblCpError.Text = "";
            }

            if (!chkTerminos.Checked)
            {
                lblTerminosError.Text = "Debe aceptar los términos y condiciones";
                err = true;
            }
            else
            {
                lblTerminosError.Text = "";
            }

            return err;
        }

        private bool validarCampo(TextBox campo, Label errorLabel, string mensajeError)
        {
            if (campo.Text.Trim().Length < 3)
            {
                errorLabel.Text = mensajeError;
                return true;
            }
            errorLabel.Text = "";
            return false;
        }

        public static bool validarMail(TextBox campo, Label errorLabel, string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(campo.Text.Trim()))
                return false;

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(campo.Text.Trim(), patron, RegexOptions.IgnoreCase))
            {
                errorLabel.Text = mensajeError;
                return true;
            }
            errorLabel.Text = "";
            return false;
        }

        private void mostrarError(string titulo, string cuerpo)
        {
            lblTituloError.Text = titulo;
            lblCuerpoError.Text = cuerpo;
            string script = "var modal = new bootstrap.Modal(document.getElementById('modalError')); modal.show();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalError", script, true);
        }
    }
}
