<%@ Page Title="" Language="C#" MasterPageFile="~/Usuarios/NavUsuarios.Master" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Usuarios.PaginaInicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 style="text-align: center;">Usuarios</h3>
                <br />

                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 24rem;">
                    <div class="row g-2">


                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <br />
                            <asp:Button ID="beca_btn" runat="server" type="button" class="btn btn-success" Text="Actualizar Becas" OnClick="Becas_Click" />

                        </div>

                        <br />
                        <br />

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <asp:Button ID="admin_btn" runat="server" type="button" class="btn btn-secondary" Text="Administrar usuarios" OnClick="Admin_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <br />
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Usuarios",
                    content: "En esta apartado se puede administrar las becas de los estudiantes registrados en los sistemas y los roles y permisos de cada usuario.",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                },
                {
                    title: "Botón de aministrar becas",
                    content: "Envía al usuario al apartado en el que se puedan administrar las becas",
                    target: "#<%=beca_btn.ClientID%>",
                    placement: "right",
                    showPrevButton: true,
                    showCloseButton: true,
                },
                {
                    title: "Botón de aministrar usuarios",
                    content: "Envía al usuario al apartado en el que se puedan administrar los roles y los permisos de cada usuario",
                    target: "#<%=admin_btn.ClientID%>",
                    placement: "right",
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
