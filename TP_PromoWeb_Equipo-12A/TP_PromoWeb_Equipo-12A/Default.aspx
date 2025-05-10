<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_PromoWeb_Equipo_12A.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex flex-column align-items-center text-center">

        <div class="card mx-auto my-3 w-100" style="max-width: 960px;">
            <div class="card-body">
                <h1 class="card-title">🎉¡Gran Sorteo!🎉</h1>
                <h4 class="card-text">¿Nos volvimos locos? Puede ser!</h4>
                <h5 class="card-text">Con tu compra realizada en nuestros comercios adheridos te haremos la entrega de un voucher para participar por increíbles premios!</h5>
                <br />
                <h3 class="card-title">¿Cómo participar?</h3>
                <h5 class="card-text">Ingresa el código que figura en tu voucher, elegí el premio que más te guste, completa el formulario con tus datos y ya estás participando!</h5>
                <h5 class="card-text">¿Qué esperas? Participa!</h5>
            </div>
        </div>
        <div class="card " style="width: 18rem;">
            <img src="https://cdn-icons-png.flaticon.com/512/3209/3209955.png" class="card-img-top" alt="regalo">
            <div class="card-body d-grid gap-2">
                <a href="CargaVoucher.aspx" class="btn btn-success">¡Participa!</a>
            </div>
        </div>
    </div>

</asp:Content>
