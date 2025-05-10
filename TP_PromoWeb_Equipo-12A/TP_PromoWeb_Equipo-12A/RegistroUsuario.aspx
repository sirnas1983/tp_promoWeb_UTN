<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="TP_PromoWeb_Equipo_12A.RegistroUsuario" %>


<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input[readonly], textarea[readonly], select[readonly] {
            background-color: #e9ecef;
            color: #6c757d;
            cursor: not-allowed;
        }
    </style>

    <asp:HiddenField ID="hdnIdCliente" runat="server" />
    <asp:HiddenField ID="hdnIdArticulo" runat="server" />
    <asp:HiddenField ID="hdnVoucher" runat="server" />


    <div class="container mt-4">
        <h2 class="mb-4">¡Ultimo pasito! ¡¡A registrarse!!</h2>

        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">DNI</label>
            <div class="col-sm-6 d-flex">
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control me-2" />
                <asp:Button ID="btnBuscarDni" runat="server" Text="🔍" CssClass="btn btn-outline-secondary" OnClick="btnBuscarDni_Click" />
            </div>

        </div>
        <div class="row mb-3">
            <div class="col-sm-4">
                <asp:Label ID="lblDni" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">Nombre</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-sm-4">
                <asp:Label ID="lblNombreError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">Apellido</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-sm-4">
                <asp:Label ID="lblApellidoError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mb-3">
            <label for="txtEmail" class="col-sm-2 col-form-label">Correo electrónico</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true" TextMode="Email" placeholder="nombre@ejemplo.com" />
            </div>

            <asp:Label ID="lblEmailError" runat="server" CssClass="text-danger" />
        </div>


        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">Direccion</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-sm-4">
                <asp:Label ID="lblDireccionError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">Ciudad</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-sm-4">
                <asp:Label ID="lblCiudadError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-sm-2 col-form-label">Codigo Postal</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCp" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-sm-4">
                <asp:Label ID="lblCpError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-sm-6 offset-sm-2">
                <div class="form-check">
                    <asp:CheckBox ID="chkTerminos" runat="server" CssClass="form-check-input" Enabled="false" />
                    <label class="form-check-label" for="chkTerminos">Acepto términos y condiciones</label>
                </div>
                <asp:Label ID="lblTerminosError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-sm-6 offset-sm-2">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary me-2" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" PostBackUrl="~/Default.aspx" />
            </div>
        </div>
    </div>
    <!-- Modal de error -->
    <div class="modal fade" id="modalError" tabindex="-1" aria-labelledby="modalErrorLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white">
                    <h5 class="modal-title">
                        <asp:Label ID="lblTituloError" runat="server" Text="Error de registro"></asp:Label>
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblCuerpoError" runat="server" Text="No se pudo registrar el usuario. Verifique los datos ingresados."></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
