using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;
using Dominio;
using System.Data.SqlClient;

namespace TP_PromoWeb_Equipo_12A
{
    public partial class CargaVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["intentos"] != null && int.Parse(Session["intentos"].ToString()) >= 3)
            {
                lblError.Text = "Por cuestiones de seguridad debe cerrar y volver a abrir el navegador";
                txtVoucher.Enabled = false;
                return;
            }
        }

        protected void btnBuscarVoucher_Click(object sender, EventArgs e)
        {
            string voucher = txtVoucher.Text;
           
            if (!string.IsNullOrWhiteSpace(voucher))
            {
                if(Session["intentos"] == null)
                    Session.Add("intentos",0);
                Session["intentos"] = int.Parse(Session["intentos"].ToString()) + 1;
                if (int.Parse(Session["intentos"].ToString()) >= 3)
                {
                    lblError.Text = "Por cuestiones de seguridad debe cerrar y volver a abrir el navegador";
                    txtVoucher.Enabled = false;
                    return;
                }
                ServicioVoucher servicioVoucher = new ServicioVoucher();
                Voucher v = servicioVoucher.buscarVoucher(voucher);

                if (servicioVoucher.voucherExiste(v))
                {
                    if (servicioVoucher.esVoucherCanjeable(v))
                    {
                        Session.Add("voucher", v.CodigoVoucher.ToString());
                        Response.Redirect("ElegirPremio.aspx");
                    }
                    else
                    {
                        lblError.Text = "El voucher ya fue canjeado.";
                    }
                }
                else
                {
                    lblError.Text = $"Voucher inexistente.";
                }
            }
        }

    }
}