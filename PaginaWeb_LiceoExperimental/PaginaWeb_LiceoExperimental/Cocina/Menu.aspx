<%@ Page Title="" Language="C#" MasterPageFile="~/Cocina/NavCocina.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 style="text-align: center;">Administración de Cocina</h3>
                <br />

                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 24rem;">
                    <div class="row g-2">


                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <br />
                            <asp:Button ID="almuerzo_btn" runat="server" type="button" class="btn btn-success" Text="Administrar Almuerzos" OnClick="Almuerzo_Click" />

                        </div>

                        <br />
                        <br />

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <asp:Button ID="reserva_btn" runat="server" type="button" class="btn btn-warning" Text="Ver lista de Reservas" OnClick="Reservas_Click" />
                        </div>

                        <br />
                        <br />

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <asp:Button ID="pago_btn" runat="server" type="button" class="btn btn-secondary" Text="Ver lista de Pagos" OnClick="Pago_Click" />
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

    <script>
         var myTour = {
             id: "myTour",
             steps: [
                 {
                     title: "Modulo de Almuerzos",
                     content: "En esta ´sección encontrarás diferentes opciones de gestion relacionadas con la administración de almuerzos",
                     target: "#<%=formulario.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                },
                {
                    title: "Almuerzos",
                    content: "Aquí podremos administrar los diferentes aspectos de los almuerzos. Añadir nuevos platillos, eliminarlos, modificarlos o seleccionar el almuerzo del día.",
                    target: "#<%=almuerzo_btn.ClientID%>",
                    placement: "left",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Lista de Reservas",
                    content: "En esta opción se nos mostrarán todas las reservas actuales del platillo actual seleccionado para el almuerzo. Igualmente podemos cotrolar a que estudiantes se les ha entregado su porción",
                    target: "#<%=reserva_btn.ClientID%>",
                    placement: "left",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Lista de Pagos",
                    content: "Esta opción es para generar la reserva de los profesores y estudiantes no becados. Cada estudiante/profesor deberá pagar para obtener el beneficio del almuerzo, y es por medio de esta vista donde se realiza la reserva una vez procesado el pago",
                    target: "#<%=pago_btn.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                 },

             ]

         };

         $(document).on("click", "a[name='guia']", function (e) {
             hopscotch.startTour(myTour);
         });


    </script>

</asp:Content>
