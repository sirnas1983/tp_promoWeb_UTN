<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="TP_PromoWeb_Equipo_12A.ElegirPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /*Aca para que las card no se rompan con la imagenes de diferente tam*/
        .carousel-inner img {
            max-height: 250px;
            width: 100%;
            object-fit: contain;
        }

        .card {
            height: 100%;
        }

            .card .carousel,
            .card .carousel-inner {
                height: 250px;
            }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>🎁 Elegí tu premio: </h1>
    <br />
    <%  //int indice = 0; 
//Container.ItemIndex = me sirve para conocer el indice donde estoy, para los repetaer :D
    %>

    <div class="row row-cols-1 row-cols-md-3 ">

        <asp:Repeater ID="rptArticulo" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card mb-4">
                        <div id='carousel<%# Container.ItemIndex %>' class="carousel carousel-dark slide" data-bs-ride="false">
                            <div class="carousel-inner">

                                <asp:Repeater ID="rptImagenes" DataSource='<%# Eval("Imagenes") %>' runat="server">
                                    <itemtemplate>

                                        <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                            <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" alt="..." />
                                        </div>
                                    </itemtemplate>
                                </asp:Repeater>

                            </div>

                            <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Container.ItemIndex %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>

                            <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Container.ItemIndex %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>

                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <!--Provisorio para redireccionar a la page de carga del cliente, para probar-->
                            <a href="RegistroUsuario.aspx?idArticulo=<%# Eval("IdArticulo") %>" class="btn btn-primary">Elegir</a>
                        </div>
                    </div>
                </div>
                <!--<% //indice++; %>-->
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
