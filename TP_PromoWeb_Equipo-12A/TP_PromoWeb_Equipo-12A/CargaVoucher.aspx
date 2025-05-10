<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CargaVoucher.aspx.cs" Inherits="TP_PromoWeb_Equipo_12A.CargaVoucher" %>

<asp:Content ID="ContenidoVoucher" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h2 class="mb-4">¡Ingresa el código de tu voucher!</h2>

        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">N° Voucher</label>
            <div class="col-sm-6 d-flex">
                <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control me-2" />
                <asp:Button ID="btnBuscarVoucher" runat="server" Text="🔍" OnClick="btnBuscarVoucher_Click" CssClass="btn btn-outline-secondary" />

            </div>
        </div>
        <div class="row mb-3">
            <div class="col-sm-4">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" />
            </div>
        </div>
    </div>
</asp:Content>
