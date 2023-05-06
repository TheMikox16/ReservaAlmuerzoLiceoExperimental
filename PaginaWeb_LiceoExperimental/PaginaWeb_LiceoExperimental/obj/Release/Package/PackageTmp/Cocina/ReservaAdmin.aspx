<%@ Page Title="" Language="C#" MasterPageFile="~/Cocina/NavCocina.Master" AutoEventWireup="true" CodeBehind="ReservaAdmin.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.ReservaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Vista para la reserva de almuerzos para usuarios que tenga permisos -->

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Almuerzo del día</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 300rem;">

                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-5">

                            <img id="img_fld" runat="server" src="" style="width: 100%; height: 100%; border-radius: 10px; padding: 10px;"/>
                            
                        </div>

                        
                        

                        <div class="col-sm-7">
                            <label id="titulo_lbl" runat="server" class="form-label control-label col-sm-12" style="font-size: 30px;"></label> 
                            <label id="descripcion_lbl" runat="server" class="form-label control-label col-sm-12" style="background-color: white; color: gray; border-radius: 10px; padding: 15px;"> </label>
                            <p align="right">
                                <asp:Button ID="regresar_btn" type="button" runat="server" class="btn btn-dark" Text="Regresar" OnClick="Regresar_Click" formnovalidate />
                                <asp:Button ID="administrar_btn" runat="server" type="button" class="btn btn-warning" Text="Administrar" OnClick="Administrar_Click"  />
                                <asp:Button ID="reservar_btn" runat="server" type="button" class="btn btn-success" Text="Reservar" OnClick="Reservar_Click"  />
                            </p>
                        </div>

                        

                        
                    </div>

                </form>

            </div>
        </div>
     </div>
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
                     title: "Reserva de Admin",
                     content: "En esta pantalla puedes reservar tu almuerzo si es que ya se ha seleccionado un almuerzo para el día de hoy o mañana",
                     target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Sobre administradores",
                    content: "Los administradores pueden reservar su almuerzo en cualquier momento, pero de preferencía usar esto con producencia o dejar que la encargada de los pagos haga la reserva por usted",
                    target: "#<%=descripcion_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "BAdministración",
                    content: "Si se desea administrar los platillos y obtener más información de los mismos, por favor seleccione esta opción",
                    target: "#<%=administrar_btn.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                 },
                 {
                     title: "Regresar",
                     content: "Haga click en este botón para volver al menú anterior",
                     target: "#<%=regresar_btn.ClientID%>",
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
