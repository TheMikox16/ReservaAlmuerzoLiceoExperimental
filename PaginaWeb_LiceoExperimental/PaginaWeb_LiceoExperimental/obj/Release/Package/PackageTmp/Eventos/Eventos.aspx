﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Eventos/NavEventos.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Eventos.Eventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%">
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Eventos</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 200rem;">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">

                        <ContentTemplate>

                            <div class="row g-2">

                                
                                <!-- Tabla -->
                                <div class="container-fluid">
                                    <div class="row flex-row flex-nowrap overflow-scroll">
                                        <%= DataGridCreation()%>
                                    </div>
                                </div>

                                <div class="col-sm-12 h-100 d-flex align-items-center justify-content-center">
                                    <asp:Button ID="admin_btn" type="button" runat="server" class="btn btn-success" Text="Administrar" OnClick="Administrar_Click" formnovalidate />
                                </div>

                            </div>

                            

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>

            </div>
        </div>
    </div>
    
        <br />
    <br />
    <br />
    <br />

    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Eventos publicados",
                    content: "En esta sección pueden observar todos los eventos vigentes y su información correspondiente resumida.",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                },
                {
                    title: "Botón de administrar",
                    content: "Al presionar este botón permite ingresar al apartado donde se pueden adminitrar todos los eventos, tanto antiguos como vigentes ",
                    target: "#<%=admin_btn.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                }
                
            ]

        };

        $(document).on("click", "a[name='guia']", function (e) {
            hopscotch.startTour(myTour);
        });


    </script>

</asp:Content>
